using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class TipoTelefone
    {
        public TipoTelefone()
        {
            Telefone = new HashSet<Telefone>();
        }
        public Guid TipoTelefoneId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required]
        public bool Status { get; set; }
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
