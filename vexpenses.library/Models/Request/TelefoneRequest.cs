using System;
using System.ComponentModel.DataAnnotations;
using vexpenses.library.Entities;

namespace vexpenses.library.Models.Request
{
    public class TelefoneRequest
    {
        [Required]
        [MaxLength(2)]
        public string DDD { get; set; }

        [Required]
        [MaxLength(9)]
        public string Numero { get; set; }

        [Required]
        public Guid TipoTelefoneId { get; set; }

        public Telefone ConvertyToEntity()
        {
            return new Telefone
            {
                DDD = DDD.Trim(),
                Numero = Numero.Trim(),
                Status = true,
                TipoTelefoneId = TipoTelefoneId
            };
        }
    }
}
