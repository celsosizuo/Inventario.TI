using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Accounts;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Inventario.TI.BackEnd.Interfaces.FilaEMails;
using Inventario.TI.BackEnd.Interfaces.TokenNumericos;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Models;
using Inventario.TI.Core.Exceptions.Empresa;
using Inventario.TI.Core.Exceptions.TokenNumerico;
using Inventario.TI.Core.Exceptions.Usuario;
using Inventario.TI.Core.Extensions;
using Newtonsoft.Json;

namespace Inventario.TI.BackEnd.Services
{
    public class AccountService : IAccountService
    {
        private readonly IEmpresaService _empresaService;
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenNumericoService _tokenNumericoService;
        private readonly IEmailService _emailService;
        private readonly IFilaEmailService _filaEmailService;

        public AccountService(IEmpresaService empresaService, IUsuarioService usuarioService,
            ITokenNumericoService tokenNumericoService, IEmailService emailService, IFilaEmailService filaEmailService)
        {
            _empresaService = empresaService;
            _usuarioService = usuarioService;
            _tokenNumericoService = tokenNumericoService;
            _emailService = emailService;
            _filaEmailService = filaEmailService;
        }

        public async Task<bool> CriarConta(ContaModel conta)
        {

            var empresa = await _empresaService.Inserir(conta.Empresa) ?? throw new InvalidOperationException("Problema ao cadastrar a empresa");
            
            conta.Usuario.Empresa = empresa;
            conta.Usuario.Role = "Admin";

            var usuario = await _usuarioService.Inserir(conta.Usuario) ?? throw new InvalidOperationException("Problema oa cadastrar o usuário");
            await EnviarEmail(empresa, usuario);
            return true;
        }
        public async Task<bool> AtivarConta(string chave)
        {
            var model = ConverterString(chave);
            var usuario = await _usuarioService.GetByIdExterno(model.IdExterno) ?? throw new UsuarioNaoEncontradoException();
            
            if (usuario.Empresa == null)
                throw new EmpresaNaoEncontradaException();

            var empresa = await _empresaService.GetByIdExterno(usuario.Empresa.IdExterno) ?? throw new EmpresaNaoEncontradaException();

            await _tokenNumericoService.ValidarToken(usuario, model.Token);

            await AtivarUsuario(usuario.IdExterno);
            await AtivarEmpresa(empresa.IdExterno);

            return true;
        }
        private async Task AtivarUsuario(Guid idExternoUsuario)
        {
            _ = await _usuarioService.Ativar(idExternoUsuario);
        }
        private async Task AtivarEmpresa(Guid idExternoEmpresa)
        {
            _ = await _empresaService.Ativar(idExternoEmpresa);
        }
        private static DtoAtivarConta ConverterString(string chave)
        {
            var objetoString = StringExtension.Base64Decode(chave);
            return JsonConvert.DeserializeObject<DtoAtivarConta>(objetoString) ?? throw new InvalidDataException("Dados inválidos");
        }
        private static FilaEMail CriarFilaEmail(string? destinatario, string mensagem, Empresa empresa, Usuario usuario)
        {
            return new FilaEMail()
            {
                Assunto = "CSHJU - Sistema de Invenátio de TI - Criação de Conta",
                Destinatario = destinatario ?? throw new ArgumentNullException(destinatario),
                Mensagem = mensagem,
                Status = Enum.StatusFilaEmail.Pendente,
                Empresa = empresa,
                IdUsuarioCriacao = usuario.Id,
            };
        } 
        private async Task EnviarEmail(Empresa empresa, Usuario usuario)
        {
            var token = await _tokenNumericoService.Inserir(usuario.IdExterno);
            var mensagem = _emailService.MontarEmailCriacaoConta(usuario.IdExterno, token.Token);
            var filaEmail = CriarFilaEmail(usuario.Login, mensagem, empresa, usuario);
            await _filaEmailService.Inserir(filaEmail);
        }
    }
}
