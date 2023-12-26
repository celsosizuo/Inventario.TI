using Inventario.TI.Core.Seguranca;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    //[Route("api/{dominio}/[controller]")]
    [Route("api/[controller]")]
    //[Authorize("Bearer")]
    public abstract class WebControllerBase : ControllerBase
    {
        protected string? GetLoginExterno() => HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimExtensionscs.CLAIM_SUB)?.Value;
        protected bool IsInRole(string role) => HttpContext.User.IsInRole(role);
    }
}
