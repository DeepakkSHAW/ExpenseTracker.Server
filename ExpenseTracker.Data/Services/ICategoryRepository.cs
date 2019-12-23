using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public interface ICategoryRepository
    {
        string ADummyMethod(string s = null);

        Task<IEnumerable<ExpenseCategory>> GetCategoriesAsync();
        Task<IEnumerable<ExpenseCategory>> GetCategoriesAsync(bool Ascecnding);
        Task<KeyValuePair<int, string>> GetExpenseCategoryAsync_KeyValue(int CategoryID);
        Task<ExpenseCategory> GetExpenseCategoryAsync(int CategoryID);

    }
}
