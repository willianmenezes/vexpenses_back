using System;
using System.ComponentModel.DataAnnotations;
using vexpenses.library.Entities;

namespace vexpenses.library.Models.Request
{
    public class AgendaRequest
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(400)]
        public string Descricao { get; set; }

        [Required]
        public Guid TipoAgendaId { get; set; }

        public Agenda ConvertToEntity()
        {
            return new Agenda
            {
                Nome = Nome == null ? null : Nome.Trim(),
                Descricao = Descricao == null ? null : Descricao.Trim(),
                Status = true,
                TipoAgendaId = TipoAgendaId
            };
        }
    }
}
