using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Data.Services
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private ETDBContext _ctx;
        public CurrencyRepository() { _ctx = new ETDBContext(); }

        public async Task<IEnumerable<Currency>> GetCurrencyAsync()
        {
            var quary = from c in _ctx.Currencies select c;

            return await quary.ToListAsync();
        }
        public async Task<IEnumerable<Currency>> GetCurrencyAsync(bool IsAscend)
        {
            var quary = from c in _ctx.Currencies select c;

            if (IsAscend)
                quary = quary.OrderBy(x => x.CurrencyName);
            else
                quary = quary.OrderByDescending(x => x.CurrencyName);

            return await quary.ToListAsync();
        }
        public async Task<Currency> GetCurrencyAsync(int id)
        {
            var quary = await _ctx.Currencies
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return quary;
        }


    }
}
