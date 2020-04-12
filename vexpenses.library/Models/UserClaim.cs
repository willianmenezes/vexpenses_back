using System;
using System.ComponentModel.DataAnnotations;
using vexpenses.library.Entities;

namespace vexpenses.library.Models
{
    public class UserClaim
    {
        [Required]
        public Guid PessoaId { get; set; }

        [Required]
        public string Email { get; set; }

        public static UserClaim ConvertEntityToClaim(Pessoa pessoa)
        {
            return new UserClaim
            {
                PessoaId = pessoa.PessoaId,
                Email = pessoa.Email
            };
        }
    }
}
