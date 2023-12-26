using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.TokenNumericos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenNumericoController : WebControllerBase
    {
        private readonly ITokenNumericoService _tokenNumericoService;

        public TokenNumericoController(ITokenNumericoService tokenNumericoService)
        {
            _tokenNumericoService = tokenNumericoService;
        }

        [HttpPost("GerarToken")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GerarToken(Guid idExterno)
        {
            var token = await _tokenNumericoService.Inserir(idExterno);
            return Ok(token);
        }
    }
}
