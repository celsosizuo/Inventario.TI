using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Models;

namespace Inventario.TI.BackEnd.Interfaces.Accounts
{
    public interface IAccountService
    {
        Task<bool> CriarConta(ContaModel conta);
        Task<bool> AtivarConta(string chave);
    }
}
