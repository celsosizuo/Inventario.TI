using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : WebControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Inserir")]
        [Authorize]
        public async Task<ActionResult<bool>> Inserir(Usuario model)
        {
            var retorno = await _usuarioService.Inserir(model);
            return Ok(retorno);
        }

        [HttpPut("Alterar")]
        [Authorize]
        public async Task<ActionResult<bool>> Alterar(Usuario model)
        {
            var retorno = await _usuarioService.Alterar(model);
            return Ok(retorno);
        }

        [HttpGet("Consultar")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> Consultar()
        {
            var teste = GetLoginExterno();
            var teste2 = IsInRole("Adminaaa");
            var retorno = await _usuarioService.Get();
            return Ok(retorno);
        }
    }
}
