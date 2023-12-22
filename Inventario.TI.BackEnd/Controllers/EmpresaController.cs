using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    public class EmpresaController : WebControllerBase
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("Inserir")]
        [Authorize]
        public async Task<ActionResult<bool>> Inserir(Empresa model)
        {
            var retorno = await _empresaService.Inserir(model);
            return Ok(retorno);
        }

        [HttpPut("Alterar")]
        [Authorize]
        public async Task<ActionResult<bool>> Alterar(Empresa model)
        {
            var retorno = await _empresaService.Alterar(model);
            return Ok(retorno);
        }

        [HttpGet("Consultar")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Empresa>>> Consultar()
        {
            var retorno = await _empresaService.Get();
            return Ok(retorno);
        }
    }
}
