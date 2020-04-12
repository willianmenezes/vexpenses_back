using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class Agenda
    {

        public Agenda()
        {
            AgendaContato = new HashSet<AgendaContato>();
        }

        public Guid AgendaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(400)]
        public string Descricao { get; set; }

        [Required]
        public Guid TipoAgendaId { get; set; }

        [Required]
        public Guid PessoaId { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual TipoAgenda TipoAgenda { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<AgendaContato> AgendaContato { get; set; }
    }
}
