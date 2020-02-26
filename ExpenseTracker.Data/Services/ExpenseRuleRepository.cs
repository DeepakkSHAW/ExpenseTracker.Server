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
            var quary = from c in _ctx.ExpenseRules select c;

            return await quary.ToListAsync();
        }
        public async Task<ExpenseRule> FindExpenseAsync(string tofind)
        {
            var expRule = new ExpenseRule();
            expRule = await _ctx.ExpenseRules
                .Where(f => expRule.SearchText.Contains(tofind)).FirstOrDefaultAsync();

            return expRule;
        }
    }
}
