using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.library.Models.Request
{
    public class EnderecoRequest
    {
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
        public bool Status { get; set; }

        public Endereco ConvertyToEntity()
        {
            return new Endereco
            {
                Bairro = Bairro.Trim(),
                Cep = Cep.Trim(),
                Complemento = Complemento.Trim(),
                Localidade = Localidade.Trim(),
                Logradouro = Logradouro.Trim(),
                Status = true,
                Uf = Uf.Trim()
            };
        }
    }
}
