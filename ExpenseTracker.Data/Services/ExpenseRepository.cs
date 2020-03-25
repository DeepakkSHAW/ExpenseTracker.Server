using EFCore.BulkExtensions;
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

        public async Task<bool> BulkNewExpensesAsync(List<Expense> expenses)
        {
            bool vReturn = false;
            if (expenses != null)
            {
                try
                {
                   // _ctx.BulkInsert(expenses);
                   await _ctx.BulkInsertAsync(expenses);
                    vReturn = true;
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return vReturn;
        }

        public async Task<int> DeleteExpensesAsync(int expenseId)
        {
            var result = -1;
            var entiry = _ctx.Expenses.Include(d => d.ExpenseDetail).FirstOrDefault(x => x.Id == expenseId);
            if (entiry != null)
            {
                _ctx.Expenses.Attach(entiry);
                _ctx.Expenses.Remove(entiry);
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
                    _ctx.Entry(entiry).State = EntityState.Modified;
                    //_ctx.Expenses.Update(entiry);
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

        public async Task<Tuple<DateTime, DateTime>> GetExpenseRangeDatesAsync()
        {
            DateTime from = DateTime.Now.Date;
            DateTime to = DateTime.Now.Date;
            var result = new Tuple<DateTime, DateTime>(from, to);
            try
            {
                result = new Tuple<DateTime, DateTime>(
                    await _ctx.Expenses.Select(i => i.ExpenseDate).MinAsync(),
                    await _ctx.Expenses.Select(i => i.ExpenseDate).MaxAsync());
            }
            catch (Exception)
            {
                throw;
            }
            return result;
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

        public async Task<Tuple<IEnumerable<Expense>, double>> GetExpensesAsync(DateTime from, DateTime to,
            PaginationDTO pagination)
        {
            double pagesQuantity = 0;
            var result = new Tuple<IEnumerable<Expense>, double>(null, 0);
            //var queryable = _ctx.Expenses.AsQueryable();
            try
            {
                var queryable = _ctx.Expenses.OrderByDescending(x => x.ExpenseDate)
               .Include(s => s.Category)
               .Include(s => s.Currency)
               .Include(s => s.ExpenseDetail)
               .Where(d => d.ExpenseDate >= from && d.ExpenseDate <= to);
               //.Skip((pagination.Page - 1) * pagination.QuantityPerPage)
               //.Take(pagination.QuantityPerPage);


                double count = await queryable.CountAsync();
                pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);
                //pagesQuantity = 10;
                queryable = queryable.Skip((pagination.Page - 1) * pagination.QuantityPerPage)
               .Take(pagination.QuantityPerPage);
                result = new Tuple<IEnumerable<Expense>, double>(await queryable.ToListAsync(), pagesQuantity);
            }
            catch (Exception)
            {
                throw;
            }
            //return await queryable.Paginate(pagination).ToListAsync();
            //return new Tuple<IEnumerable<Expense>, double>(await queryable.ToListAsync(), pagesQuantity);
            return result;
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
