using Inventario.TI.BackEnd.Interfaces.Accounts;
using Inventario.TI.BackEnd.Interfaces.Authentication;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Inventario.TI.BackEnd.Interfaces.FilaEMails;
using Inventario.TI.BackEnd.Interfaces.TokenNumericos;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Repositories;
using Inventario.TI.BackEnd.Services;
using Inventario.TI.Core.Seguranca;

namespace Inventario.TI.BackEnd
{
    public static class IoC
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPwdHasher, PwdHasher>();
            services.AddSingleton<IEmailService, EmailService>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenNumericoRepository, TokenNumericoRepository>();
            services.AddScoped<ITokenNumericoService, TokenNumericoService>();
            services.AddScoped<IFilaEmailService, FilaEMailService>();
            services.AddScoped<IFilaEmailRepository, FilaEmailRepository>();
        }
    }
}
