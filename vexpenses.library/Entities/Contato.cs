using System;

namespace vexpenses.library.Entities
{
    public class Contato
    {
        public Guid ContatoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
