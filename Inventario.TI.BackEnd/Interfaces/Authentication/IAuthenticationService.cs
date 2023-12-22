using Inventario.TI.BackEnd.Models;

namespace Inventario.TI.BackEnd.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(LoginModel login);
    }
}
