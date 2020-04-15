using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vexpenses.business.Components;
using vexpenses.library.Entities;
using vexpenses.library.Models;
using vexpenses.library.Models.Request;
using vexpenses.library.Models.Response;

namespace vexpenses.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : VExpensesBaseController
    {
        private readonly EnderecoComponent _enderecoComponent;
        private readonly CorreiosComponent _correiosComponent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enderecoComponent"></param>
        public EnderecoController(EnderecoComponent enderecoComponent, CorreiosComponent correiosComponent)
        {
            _enderecoComponent = enderecoComponent;
            _correiosComponent = correiosComponent;
        }

        /// <summary>
        /// Cadastra um ou mais endereços de um contato
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Endereço registrado com sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpPost("{contatoId}")]
        public async Task<IActionResult> CadastrarEnderecos([FromBody] List<EnderecoRequest> request, [FromRoute] Guid contatoId)
        {
            try
            {
                await _enderecoComponent.CadastrarEnderecos(request, contatoId);

                return Ok(new RequestResponse { Mensagem = "Endereço(s) registrado(s) com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Busca dados de um endereço de acordo com o CEP digitado
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Endereço encontrado sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse<EnderecoViaCepResponse>))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpGet("{cep}")]
        public async Task<IActionResult> BuscarEnderecoPorCep([FromRoute] string cep)
        {
            try
            {
                return Ok(new RequestResponse<EnderecoViaCepResponse>
                {
                    Mensagem = "Endereço(s) registrado(s) com sucesso",
                    Resposta = await _correiosComponent.BuscarEnderecoPorCep(cep)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        } 
    }
}