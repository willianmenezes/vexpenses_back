using System;

namespace vexpenses.library.Entities
{
	public class Endereco
    {
		public Guid EnderecoId { get; set; }
		public string Cep { get; set; }
		public string Logradouro { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public string Localidade { get; set; }
		public string Uf { get; set; }
		public Guid ContatoId { get; set; }
		public bool Status { get; set; }
	}
}
