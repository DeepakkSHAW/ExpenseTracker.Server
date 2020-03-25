using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesAsync();
        Task<Tuple<DateTime, DateTime>> GetExpenseRangeDatesAsync();
        Task<Expense> GetExpensesAsync(int id);
        Task<bool> ExpenseExist(int id);
        Task<IEnumerable<Expense>> GetExpensesAsync(DateTime from, DateTime to);
        Task<Tuple<IEnumerable<Expense>, double>> GetExpensesAsync(DateTime from, DateTime to, PaginationDTO pagination);
        Task<int> NewExpensesAsync(Expense expense);
        Task<bool> BulkNewExpensesAsync(List<Expense> expenses);
        Task<int> DeleteExpensesAsync(int expenseId);
        Task<int> EditExpensesAsync(Expense expense, int id);

        void DeleteIT(string message, int times = 1, int lineBreaks = 1);
    }
}
