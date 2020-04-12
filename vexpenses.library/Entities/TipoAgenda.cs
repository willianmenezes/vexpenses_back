using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class TipoAgenda
    {
        public TipoAgenda()
        {
            Agenda = new HashSet<Agenda>();
        }
        public Guid TipoAgendaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}
