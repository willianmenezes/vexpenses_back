using System;

namespace vexpenses.library.Models.Response
{
    public class TipoAgendaResponse
    {
        public Guid TipoAgendaId { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
    }
}
