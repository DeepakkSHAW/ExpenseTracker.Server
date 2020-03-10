using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public class ExpenseRuleRepository : IExpenseRuleRepository
    {
        private ETDBContext _ctx;
        public ExpenseRuleRepository() { _ctx = new ETDBContext(); }
        public async Task<ExpenseRule> GetExpenseRuleAsync(int id)
        {
            var quary = await _ctx.ExpenseRules
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return quary;
        }

        public async Task<IEnumerable<ExpenseRule>> GetExpenseRulesAsync()
        {
            //var quary = from c in _ctx.ExpenseRules select c ;
            var quary = _ctx.ExpenseRules.OrderBy(x => x.Priority);
            return await quary.ToListAsync();
        }
        public async Task<ExpenseRule> FindExpenseAsync(string tofind)
        {
            var expRule = new ExpenseRule();
            expRule = await _ctx.ExpenseRules
                .Where(f => expRule.SearchText.Contains(tofind)).FirstOrDefaultAsync();

            return expRule;
        }

        public async Task<int> NewExpenseRuleAsync(ExpenseRule expRule)
        {

            var result = -1;
            try
            {
                _ctx.Add(expRule);
                result = await _ctx.SaveChangesAsync();
                if (result < 1)
                    throw new Exception("Error occurred while adding new expense rule into database");
                result = expRule.Id;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public async Task<bool> UpdateExpenseRuleAsync(ExpenseRule expRule, int id)
        {
            bool vResult = false;
            var entiry = _ctx.ExpenseRules.FirstOrDefault(x => x.Id == id);
            try
            {
                if (entiry != null)
                {
                    entiry.RuleName = expRule.RuleName;
                    entiry.SearchText = expRule.SearchText;
                    entiry.IsActiveRule = expRule.IsActiveRule;
                    entiry.Priority = expRule.Priority;
                    entiry.ExpenseCategoryId = expRule.ExpenseCategoryId;
                    entiry.CurrencyId = expRule.CurrencyId;
                    entiry.PaymentMethod = expRule.PaymentMethod;
                    entiry.PaymentType = expRule.PaymentType;
                    entiry.updateDate = DateTime.UtcNow;
                    _ctx.Entry(entiry).State = EntityState.Modified;
                    await _ctx.SaveChangesAsync();
                    vResult = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vResult;
        }
        public async Task<int> DeleteExpenseRuleAsync(int ruleId)
        {
            var result = -1;
            var entiry = _ctx.ExpenseRules.FirstOrDefault(x => x.Id == ruleId);
            if (entiry != null)
            {
                _ctx.ExpenseRules.Attach(entiry);
                _ctx.ExpenseRules.Remove(entiry);
                result = await _ctx.SaveChangesAsync();
            }
            return result;
        }
    }
}
