﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class ContatoController : VExpensesBaseController
    {
        private readonly ContatoComponent _contatoComponent;
        private readonly EnderecoComponent _enderecoComponent;
        private readonly TelefoneComponent  _telefoneComponent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contatoComponent"></param>
        /// <param name="enderecoComponent"></param>
        /// <param name="telefoneComponent"></param>
        public ContatoController(ContatoComponent contatoComponent, EnderecoComponent enderecoComponent, TelefoneComponent telefoneComponent)
        {
            _contatoComponent = contatoComponent;
            _telefoneComponent = telefoneComponent;
            _enderecoComponent = enderecoComponent;
        }

        /// <summary>
        /// realiza o cadastro de uma contato para uma agenda
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Contato cadastrado com sucesso</response>
        /// <response code="400">Ocorreu algum erro com a solicitação. Esta resposta pode mostrar as propriedades do erro ou apenas uma mensagem do que acontece</response>
        /// <response code="401">Não autorizado, deve obter um token de portador válido antes de fazer esta solicitação</response>
        /// <response code="404">Dados não encontrados</response>
        [ProducesResponseType(200, Type = typeof(RequestResponse))]
        [ProducesResponseType(400, Type = typeof(RequestResponse))]
        [ProducesResponseType(401, Type = typeof(RequestResponse))]
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> CadastrarContato([FromBody] ContatoRequest request)
        {
            try
            {
                await _contatoComponent.CadastrarContato(request, _telefoneComponent, _enderecoComponent);

                return Ok(new RequestResponse { Mensagem = "Contato cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }
        }
    }
}