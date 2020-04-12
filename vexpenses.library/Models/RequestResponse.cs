using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace vexpenses.library.Models
{
    public class RequestResponse
    {
        /// <summary>
        /// Informative message from request processing
        /// </summary>
        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
    }

    /// <summary>
    /// Base response from all api requests
    /// </summary>
    public class RequestResponse<TEntity> : RequestResponse where TEntity : class
    {
        /// <summary>
        /// Data result from request processing
        /// </summary>
        [JsonProperty("response")]
        public TEntity Resposta { get; set; }
    }
}
