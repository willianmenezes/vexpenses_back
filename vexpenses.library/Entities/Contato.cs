using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Entities
{
    public class Contato
    {

        public Contato()
        {
            AgendaContato = new HashSet<AgendaContato>();
            Endereco = new HashSet<Endereco>();
            Telefone = new HashSet<Telefone>();
        }

        public Guid ContatoId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Sobrenome { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<AgendaContato> AgendaContato { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
