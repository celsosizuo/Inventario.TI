using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.Core.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Inventario.TI.BackEnd.Controllers
{
    [ApiController]
    [Route("api/{dominio}/[controller]")]
    //[Authorize("Bearer")]
    public abstract class WebControllerBase : ControllerBase
    {
        protected string? GetLoginExterno() => HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimExtensionscs.CLAIM_SUB)?.Value;
        protected bool IsInRole(string role) => HttpContext.User.IsInRole(role);
    }
}
