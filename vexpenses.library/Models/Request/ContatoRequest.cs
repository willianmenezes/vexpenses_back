using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.library.Models.Request
{
    public class ContatoRequest
    {
        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Sobrenome { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public Guid AgendaId { get; set; }

        public List<EnderecoRequest> Enderecos { get; set; }

        public List<TelefoneRequest> Telefones { get; set; }

        public Contato ConvertyToEntity()
        {
            return new Contato
            {
                Nome = Nome.Trim(),
                Sobrenome = Sobrenome == null ? null : Sobrenome.Trim(),
                Email = Email == null ? null : Email.Trim(),
                Status = true
            };
        }
    }
}
