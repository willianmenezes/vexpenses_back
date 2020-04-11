using System;

namespace vexpenses.library.Entities
{
    public class Telefone
    {
        public Guid TelefoneId { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public Guid ContatoId { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool Status { get; set; }
    }
}
