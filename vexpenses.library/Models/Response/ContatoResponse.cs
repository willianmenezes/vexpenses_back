using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models.Response
{
    public class ContatoResponse
    {
        public Guid ContatoId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public List<EnderecoResponse> Endereco { get; set; }

        public List<TelefoneResponse> Telefone { get; set; }
    }
}
