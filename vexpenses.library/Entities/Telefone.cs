using System;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }

        [Required]
        [MaxLength(2)]
        public string DDD { get; set; }

        [Required]
        [MaxLength(9)]
        public string Numero { get; set; }

        [Required]
        public Guid ContatoId { get; set; }

        [Required]
        public Guid TipoTelefoneId { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual Contato Contato { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
