using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Authentication;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Models;
using Inventario.TI.Core.Seguranca;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventario.TI.BackEnd.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IPwdHasher _pwdHasher;

        public AuthenticationService(IUsuarioService usuarioService, IConfiguration configuration, IPwdHasher pwdHasher)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
            _pwdHasher = pwdHasher;
        }
        public async Task<string> Authenticate(LoginModel login)
        {
            var usuario = await BuscarUsuarioPorLogin(login.Usuario);
            await ValidarSenha(login.Senha, usuario?.Senha ?? throw new Exception("Usuário ou senha inválidos"));
            var token = GerarToken(usuario);

            return token;
        }
        private async Task<Usuario?> BuscarUsuarioPorLogin(string login)
        {
            return await _usuarioService.GetByLogin(login) ?? throw new Exception("Login/Senha inválidos");
        }
        private async Task ValidarSenha(string senhaDigitada, string senhaArmazanada)
        {
            if (!await _pwdHasher.VerifyHashAsync(senhaDigitada, senhaArmazanada))
                throw new Exception("Usuário ou senha inválidos");
        }
        private string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["App:Jwt:Secret"] ?? throw new Exception("Ocorreu um erro ao autenticar."));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>()
                {
                    { ClaimExtensionscs.CLAIM_SUB, usuario.IdExterno.ToString() },
                    { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },
                    { ClaimExtensionscs.CLAIM_ROLE, usuario.Role ?? string.Empty }
                },
                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Name, usuario.Login ?? string.Empty),
                //    new Claim(ClaimTypes.Role, usuario.Role ?? string.Empty),
                //}),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
