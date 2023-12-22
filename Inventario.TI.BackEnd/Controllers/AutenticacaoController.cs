using Inventario.TI.BackEnd.Interfaces.Authentication;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AutenticacaoController : WebControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AutenticacaoController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Autenticar")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Autenticar(LoginModel login)
        {
            var retorno = await _authenticationService.Authenticate(login);
            return Ok(retorno);
        }
    }
}
