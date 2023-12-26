using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.Core.Seguranca;

namespace Inventario.TI.BackEnd.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPwdHasher _pwdHasher;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPwdHasher pwdHasher)
        {
            _usuarioRepository = usuarioRepository;
            _pwdHasher = pwdHasher;
        }

        public async Task<Usuario> Inserir(Usuario usuario)
        {
            usuario.IdExterno = Guid.NewGuid();
            usuario.Senha = await CriptografarSenha(usuario.Senha ?? throw new ArgumentNullException(usuario.Senha));
            return await _usuarioRepository.Inserir(usuario);
        }
        public async Task<bool> Alterar(Usuario usuario)
        {
            return await _usuarioRepository.Alterar(usuario);
        }
        public async Task<Usuario?> FindById(long id)
        {
            return await _usuarioRepository.FindById(id);
        }
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioRepository.Get();
        }
        public async Task<Usuario?> GetByIdExterno(Guid idExterno)
        {
            return await _usuarioRepository.GetByIdExterno(idExterno);
        }
        public async Task<Usuario?> GetByLogin(string login)
        {
            return await _usuarioRepository.GetByLogin(login);
        }
        public async Task<bool> Ativar(Guid idExterno)
        {
            return await _usuarioRepository.Ativar(idExterno);
        }
        public async Task<bool> AlterarSenha(DtoAlterarSenha model)
        {
            model.Senha = await CriptografarSenha(model.Senha ?? throw new ArgumentNullException(model.Senha));
            var retorno = await _usuarioRepository.AlterarSenha(model);

            return retorno;
        }
        private async Task<string> CriptografarSenha(string senha)
        {
            return await _pwdHasher.CreateHashAsync(senha);
        }
       
    }
}
