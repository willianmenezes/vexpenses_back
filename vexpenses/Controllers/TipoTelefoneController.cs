using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vexpenses.business.Components;
using vexpenses.library.Entities;
using vexpenses.library.Models;

namespace vexpenses.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTelefoneController : VExpensesBaseController
    {
        private readonly TipoTelefoneComponent _tipoTelefoneComponent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipoTelefoneComponent"></param>
        public TipoTelefoneController(TipoTelefoneComponent tipoTelefoneComponent)
        {
            _tipoTelefoneComponent = tipoTelefoneComponent;
        }

        /// <summary>
        /// Retorna os tipos de telefones que podem ser usados em um contato
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Dados encontrados com sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse<IEnumerable<TipoTelefone>>))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> BuscarTiposTelefone()
        {
            try
            {
                return Ok(new RequestResponse<IEnumerable<TipoTelefone>>
                {
                    Mensagem = "Dados encontrados com sucesso",
                    Resposta = await _tipoTelefoneComponent.BuscarTiposTelefone()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        }
    }
}