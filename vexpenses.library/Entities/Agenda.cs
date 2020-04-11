using System;

namespace vexpenses.library.Entities
{
    public class Agenda
    {
        public Guid AgendaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid TipoAgendaId { get; set; }
        public Guid PessoaId { get; set; }
        public bool Status { get; set; }
    }
}
