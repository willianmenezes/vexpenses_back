using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using vexpenses.library.Models;

namespace vexpenses.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [ApiController]
    public class VExpensesBaseController : ControllerBase
    {
        /// <summary>
        /// Return user claim
        /// </summary>
        /// <returns></returns>
        protected UserClaim GetClaim()
        {
            var claimId = User.Claims.Skip(2).Take(1).FirstOrDefault();
            var claimEmail = User.Claims.Skip(3).Take(1).FirstOrDefault();

            if (claimId == null || claimId.Type != ClaimTypes.Sid)
            {
                throw new ArgumentNullException("Claim");
            }

            if (claimEmail == null || claimEmail.Type != ClaimTypes.Email)
            {
                throw new ArgumentNullException("Claim");
            }

            return new UserClaim
            {
                Email = claimEmail.Value,
                PessoaId = Guid.Parse(claimId.Value)
            };
        }
    }
}