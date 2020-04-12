using System;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class RefreshToken
    {
        public Guid PessoaId { get; set; }

        [MaxLength(500)]
        public string Token { get; set; }

        [MaxLength(50)]
        public string Expiracao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
