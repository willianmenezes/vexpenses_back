using System;

namespace vexpenses.library.Entities
{
    public class RefreshToken
    {
        public Guid PessoaId { get; set; }
        public string Token { get; set; }
        public string Expiracao { get; set; }
    }
}
