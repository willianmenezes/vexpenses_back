using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models.Response
{
    public class TelefoneResponse
    {
        public Guid TelefoneId { get; set; }

        public string DDD { get; set; }

        public string Numero { get; set; }

        public bool Status { get; set; }

        public virtual TipoTelefoneResponse TipoTelefone { get; set; }
    }
}
