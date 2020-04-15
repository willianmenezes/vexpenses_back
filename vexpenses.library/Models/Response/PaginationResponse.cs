using System.Collections.Generic;

namespace vexpenses.library.Models.Response
{
    public class PaginationResponse<T>
    {
        public int TotalPages { get; set; }

        public int PageIndex { get; set; }

        public int TotalItens { get; set; }

        public List<T> ItemsList { get; set; }
    }
}
