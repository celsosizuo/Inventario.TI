using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<bool> Inserir(Usuario usuario);
        Task<bool> Alterar(Usuario usuario);
        Task<Usuario?> FindById(long id);
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario?> GetByIdExterno(Guid idExterno);
        Task<Usuario?> GetByLogin(string login);
    }
}
