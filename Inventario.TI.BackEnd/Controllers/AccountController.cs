using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Interfaces.Accounts;
using Inventario.TI.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : WebControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CadastrarEmpresa")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CadastrarEmpresa(ContaModel model)
        {
            var retorno = await _accountService.CriarConta(model);

            // TODO: Gerar token e enviar e-mail de ativação com um link contento o idExterno + token gerado
            return Ok(retorno);
        }

        [HttpPost("AtivarConta")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> AtivarConta(string model)
        {
            var retorno = await _accountService.AtivarConta(model);
            return Ok(retorno);
        }
    }
}
