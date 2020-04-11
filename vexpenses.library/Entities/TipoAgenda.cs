using System;

namespace vexpenses.library.Entities
{
    public class TipoAgenda
    {
        public Guid TipoAgendaId { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}
