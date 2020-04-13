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
    /// controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : VExpensesBaseController
    {
        private readonly AgendaComponent _agendaComponent;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="agendaComponent"></param>
        public AgendaController(AgendaComponent agendaComponent)
        {
            _agendaComponent = agendaComponent;
        }

        /// <summary>
        /// Registra um bibliotecário na aplicação
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Bibliotecario registrado com sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> CadastrarAgenda([FromBody] AgendaRequest request)
        {
            try
            {
                await _agendaComponent.CadastrarAgenda(GetClaim(), request);

                return Ok(new RequestResponse { Mensagem = "Agenda Cadastrada com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        }
    }
}