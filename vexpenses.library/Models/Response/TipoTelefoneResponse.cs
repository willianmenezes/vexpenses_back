using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models.Response
{
    public class TipoTelefoneResponse
    {
        public Guid TipoTelefoneId { get; set; }

        public string Descricao { get; set; }

        public bool Status { get; set; }
    }
}
