using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class AgendaContato
    {
        [Required]
        public Guid AgendaId { get; set; }

        [Required]
        public Guid ContatoId { get; set; }

        public virtual Agenda Agenda { get; set; }

        public virtual Contato Contato { get; set; }
    }
}
