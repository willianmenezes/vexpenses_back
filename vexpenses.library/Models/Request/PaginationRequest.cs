using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Models.Request
{
    public class PaginationRequest
    {
        [Required]
        public int PageIndex { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
