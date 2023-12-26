using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<Usuario> Inserir(Usuario usuario);
        Task<bool> Alterar(Usuario usuario);
        Task<Usuario?> FindById(long id);
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario?> GetByIdExterno(Guid idExterno);
        Task<Usuario?> GetByLogin(string login);
        Task<bool> Ativar(Guid idExterno);
        Task<bool> AlterarSenha(DtoAlterarSenha model);
    }
}
