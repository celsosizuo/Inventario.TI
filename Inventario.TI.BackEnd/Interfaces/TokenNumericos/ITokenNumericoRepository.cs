using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.TokenNumericos
{
    public interface ITokenNumericoRepository
    {
        Task<TokenNumerico> Inserir(TokenNumerico token);
        Task<TokenNumerico?> FindByToken(string token);
        Task<bool> UtilizarToken(TokenNumerico token);
        Task IncrementarNumeroTentativas(Guid idObjeto);
    }
}
