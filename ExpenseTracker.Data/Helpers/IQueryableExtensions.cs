using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
            PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.QuantityPerPage)
                .Take(pagination.QuantityPerPage);
        }
    }

    //public static class HttpContextExtensions
    //{
    //    public static async Task InsertPaginationParameterInResponse<T>(this HttpContext httpContext,
    //        IQueryable<T> queryable, int recordsPerPage)
    //    {
    //        double count = await queryable.CountAsync();
    //        double pagesQuantity = Math.Ceiling(count / recordsPerPage);
    //        httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
    //    }
    //}
}
