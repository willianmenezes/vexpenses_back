using System;
using System.ComponentModel.DataAnnotations;
using vexpenses.library.Entities;

namespace vexpenses.library.Models.Request
{
    public class TelefoneRequest
    {
        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string DDD { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(8)]
        public string Numero { get; set; }

        [Required]
        public Guid TipoTelefoneId { get; set; }

        public Telefone ConvertyToEntity()
        {
            return new Telefone
            {
                DDD = DDD == null ? null : DDD.Trim(),
                Numero = Numero == null ? null : Numero.Trim(),
                Status = true,
                TipoTelefoneId = TipoTelefoneId
            };
        }
    }
}
