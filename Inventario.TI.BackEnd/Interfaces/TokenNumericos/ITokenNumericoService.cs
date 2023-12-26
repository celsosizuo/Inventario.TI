using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.TokenNumericos
{
    public interface ITokenNumericoService
    {
        Task<TokenNumerico> Inserir(Guid idExterno);
        Task<TokenNumerico?> FindByToken(string token);
        Task<bool> UtilizarToken(TokenNumerico token);
        Task<bool> ValidarToken(Usuario usuario, string tokenDigitado);
    }
}
