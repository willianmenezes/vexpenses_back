﻿using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models.Response
{
    public class AgendaResponse
    {
        public Guid AgendaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Guid TipoAgendaId { get; set; }

        public Guid PessoaId { get; set; }

        public bool Status { get; set; }

        public TipoAgendaResponse TipoAgenda { get; set; }
    }
}
