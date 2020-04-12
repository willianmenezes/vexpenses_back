using System;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }

        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }

        [MaxLength(200)]
        public string Logradouro { get; set; }

        [MaxLength(200)]
        public string Complemento { get; set; }

        [MaxLength(200)]
        public string Bairro { get; set; }

        [MaxLength(200)]
        public string Localidade { get; set; }

        [MaxLength(200)]
        public string Uf { get; set; }

        [Required]
        public Guid ContatoId { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual Contato Contato { get; set; }
    }
}
