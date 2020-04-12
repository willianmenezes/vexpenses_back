using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vexpenses.business.Components;
using vexpenses.business.Security;
using vexpenses.library.Models;

namespace vexpenses.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllerController : VExpensesBaseController
    {
        private readonly UserComponent _userComponent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public AuthControllerController(UserComponent userService)
        {
            _userComponent = userService;
        }

        /// <summary>
        /// Verifica as credenciais do usuário e retorna um token de autenticação
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public object Post([FromBody] CredenciaisAcesso credentials)
        {
            try
            {
                if (credentials == null) return BadRequest();
                return Ok(_userComponent.GetByLogin(credentials));
            }
            catch (Exception ex)
            {
                return BadRequest(new RequestResponse { Mensagem = ex.Message });
            }

        }
    }
}