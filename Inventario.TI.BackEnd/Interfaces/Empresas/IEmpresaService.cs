using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.Empresas
{
    public interface IEmpresaService
    {
        Task<Empresa> Inserir(Empresa empresa);
        Task<bool> Alterar(Empresa empresa);
        Task<Empresa?> FindById(long id);
        Task<IEnumerable<Empresa>> Get();
        Task<Empresa?> GetByIdExterno(Guid idExterno);
    }
}
