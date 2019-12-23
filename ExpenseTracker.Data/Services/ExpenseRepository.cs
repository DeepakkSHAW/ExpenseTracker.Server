using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ETDBContext _ctx;
        public ExpenseRepository() { _ctx = new ETDBContext(); }
        public async Task<int> DeleteExpensesAsync(int expenseId)
        {
            var result = -1;
            var oExp = _ctx.Expenses.FirstOrDefault(x => x.Id == expenseId);
            if (oExp != null)
            {
                _ctx.Expenses.Attach(oExp);
                _ctx.Expenses.Remove(oExp);
                result = await _ctx.SaveChangesAsync();
            }
            return result;
        }

        public void DeleteIT(string message, int times = 1, int lineBreaks = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<int> EditExpensesAsync(Expense dExpenseToUpdate, int id)
        {
            var result = -1;
            var entiry = _ctx.Expenses.Include(d => d.ExpenseDetail).FirstOrDefault(x => x.Id == id);
            try
            {
                if (entiry != null)
                {
                    entiry.ExpenseTitle = dExpenseToUpdate.ExpenseTitle;
                    entiry.ExpensesAmount = dExpenseToUpdate.ExpensesAmount;
                    entiry.ExpenseDate = dExpenseToUpdate.ExpenseDate;
                    entiry.ExpenseCategoryId = dExpenseToUpdate.ExpenseCategoryId;
                    entiry.CurrencyId = dExpenseToUpdate.CurrencyId;
                    entiry.updateDate = DateTime.UtcNow;
                    entiry.ExpenseDetail = dExpenseToUpdate.ExpenseDetail;
                    entiry.Signature = dExpenseToUpdate.Signature;
                    entiry.PaymentMethod = dExpenseToUpdate.PaymentMethod;
                    entiry.PaymentType = dExpenseToUpdate.PaymentType;
                    // _expContext.Update(oExp);
                    result = await _ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<bool> ExpenseExist(int id)
        {
            bool found = false;
            var oExp = await _ctx.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (oExp.Id > 0) found = true;
            return found;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _ctx.Expenses.OrderByDescending(x => x.ExpenseDate)
                    .Include(s => s.Category)
                    .Include(s => s.Currency)
                    .Include(s => s.ExpenseDetail)
                    .ToListAsync();
        }

        public async Task<Expense> GetExpensesAsync(int id)
        {
            var result = new Expense();

            var quary = await _ctx.Expenses.OrderByDescending(x => x.ExpenseDate)
                .Include(s => s.Category)
                .Include(s => s.Currency)
                .Include(s => s.ExpenseDetail)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (quary != null)
                result = quary;

            return result;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync(DateTime from, DateTime to)
        {
            return await _ctx.Expenses.OrderByDescending(x => x.ExpenseDate)
                    .Include(s => s.Category)
                    .Include(s => s.Currency)
                    .Include(s => s.ExpenseDetail)
                    .Where(d => d.ExpenseDate >= from && d.ExpenseDate <= to)
                    .ToListAsync();
        }

        public async Task<int> NewExpensesAsync(Expense expense)
        {
            var result = -1;
            try
            {
                _ctx.Add(expense);
                result = await _ctx.SaveChangesAsync();
                if (result < 1)
                    throw new Exception("Error occurred while adding new expense into database");
                result = expense.Id;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
