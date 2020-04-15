using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vexpenses.business.Components;
using vexpenses.library.Models;
using vexpenses.library.Models.Request;

namespace vexpenses.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : VExpensesBaseController
    {
        private readonly TelefoneComponent _telefoneComponent;
        /// <summary>
        /// Contructor
        /// </summary>
        public TelefoneController(TelefoneComponent telefoneComponent)
        {
            _telefoneComponent = telefoneComponent;
        }

        /// <summary>
        /// Cadastra um ou mais telefones de um contato
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Telefone registrado com sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpPost("{contatoId}")]
        public async Task<IActionResult> CadastrarTelefones([FromBody] List<TelefoneRequest> request, [FromRoute] Guid contatoId)
        {
            try
            {
                await _telefoneComponent.CadastrarTelefones(request, contatoId);

                return Ok(new RequestResponse { Mensagem = "Telefone(s) registrado(s) com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        }
    }
}