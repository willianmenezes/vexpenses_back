using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models.Response
{
    public class EnderecoViaCepResponse
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }
    }
}
