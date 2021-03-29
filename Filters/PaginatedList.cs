using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunTogether.Filters
{
    public class PaginatedList<T> : List<T>
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int RecordsCount { get; private set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

        public PaginatedList(IList<T> items, int itemsCount, int pageNumber, int pageSize, int totalPages)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            RecordsCount = itemsCount;
            this.AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreatePagedResultAsync(IQueryable<T> data, int pageNumber, int pageSize)
        {
            var itemsCount = await data.CountAsync();
            var totalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);          
            if (pageNumber < 1 || pageNumber > totalPages)
            {
                pageNumber = 1;
            }
            var pagedItems = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(pagedItems, itemsCount, pageNumber, pageSize, totalPages);
        }
    }
}
