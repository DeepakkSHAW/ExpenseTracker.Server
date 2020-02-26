using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public interface IExpenseRuleRepository
    {
        Task<IEnumerable<ExpenseRule>> GetExpenseRulesAsync();
        Task<ExpenseRule> GetExpenseRuleAsync(int id);
        Task<ExpenseRule> FindExpenseAsync(string toFind);
    }
}
