using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetCurrencyAsync();
        Task<IEnumerable<Currency>> GetCurrencyAsync(bool Ascending);
        Task<Currency> GetCurrencyAsync(int CurID);
    }
}
