using Inventario.TI.BackEnd.Interfaces.Accounts;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Models;

namespace Inventario.TI.BackEnd.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEmpresaService _empresaService;
        private readonly IUsuarioService _usuarioService;

        public AccountService(IEmpresaService empresaService, IUsuarioService usuarioService)
        {
            _empresaService = empresaService;
            _usuarioService = usuarioService;
        }

        public async Task<bool> CadastrarConta(ContaModel conta)
        {
            var empresa = await _empresaService.Inserir(conta.Empresa);
            
            if(empresa != null)
                conta.Usuario.Empresa = empresa;

            await _usuarioService.Inserir(conta.Usuario);

            return true;
        }
    }
}
