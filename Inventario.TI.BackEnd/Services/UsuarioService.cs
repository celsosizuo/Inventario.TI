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

        public async Task<bool> Inserir(Usuario usuario)
        {
            usuario.IdExterno = new Guid(Guid.NewGuid().ToString());
            usuario.Senha = await _pwdHasher.CreateHashAsync(usuario.Senha ?? throw new Exception("O campo senha não pode ficar em branco"));
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
    }
}
