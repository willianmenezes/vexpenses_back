using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vexpenses.library.Models.Request
{
    public class PaginationRequest
    {
        [Required]
        public Guid PessoaId { get; set; }

        [Required]
        public int PageIndex { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
