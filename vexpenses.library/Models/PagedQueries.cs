using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vexpenses.library.Models
{
    public class PagedQueries<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int TotalItens { get; set; }

        public PagedQueries(List<T> itens, int itensCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalItens = itensCount;
            TotalPages = (int)Math.Ceiling(itensCount / (double)pageSize);

            this.AddRange(itens);
        }

        public static async Task<PagedQueries<T>> Create(IQueryable<T> data, int pageIndex, int pageSize)
        {
            var count = data.Count();

            var itens = await data.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedQueries<T>(itens, count, pageIndex, pageSize);
        }
    }
}
