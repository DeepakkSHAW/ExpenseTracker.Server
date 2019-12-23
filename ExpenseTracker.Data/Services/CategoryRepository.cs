using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private ETDBContext _ctx;
        public CategoryRepository() { _ctx = new ETDBContext(); }
        public string ADummyMethod(string s = null)
        {
            string defaultName = "Deepak";
            return "Hello " + s ?? defaultName;

        }

        public async Task<IEnumerable<ExpenseCategory>> GetCategoriesAsync()
        {
            //ETDBContext ctx = new ETDBContext();
            //var dummyValues = new List<ExpenseCategory> {
            //    new ExpenseCategory {Id= 1, Category= "abc" },
            //    new ExpenseCategory {Id= 2,Category= "def" } };
            try
            {

                var quary = from c in _ctx.expenseCategory select c;
                System.Diagnostics.Debug.WriteLine("Linq on Database");
                return await quary.ToListAsync();
                //System.Diagnostics.Debug.WriteLine("Init dummyValues");
                //var quary = from c in dummyValues select c;
                //System.Diagnostics.Debug.WriteLine("Linq on dummyValues");
                //return quary.ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseCategory>> GetCategoriesAsync(bool IsAscend)
        {
            var vCategory = new Dictionary<int, string>();
            var quary = from c in _ctx.expenseCategory select c;

            if (IsAscend)
                quary = quary.OrderBy(x => x.Category);
            else
                quary = quary.OrderByDescending(x => x.Category);

            return await quary.ToListAsync();
        }

        public async Task<ExpenseCategory> GetExpenseCategoryAsync(int CategoryID)
        {
            var quary = await _ctx.expenseCategory
                .Where(x => x.Id == CategoryID).FirstOrDefaultAsync();
            return quary;
        }

        public async Task<KeyValuePair<int, string>> GetExpenseCategoryAsync_KeyValue(int CategoryID)
        {
            var key = CategoryID;
            var value = string.Empty;

            var quary = await _ctx.expenseCategory
                .Where(x => x.Id == CategoryID).FirstOrDefaultAsync();

            if (quary != null)
            {
                key = quary.Id;
                value = quary.Category.First().ToString().ToUpper() + quary.Category.Substring(1);
            }
            return new KeyValuePair<int, string>(key, value);
        }
    }
}
