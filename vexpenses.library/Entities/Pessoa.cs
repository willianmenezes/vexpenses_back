using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class Pessoa
    {

        public Pessoa()
        {
            Agenda = new HashSet<Agenda>();
        }


        public Guid PessoaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Senha { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
        public virtual RefreshToken RefreshToken { get; set; }
    }
}
