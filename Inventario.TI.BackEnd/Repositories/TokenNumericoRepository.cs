using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.TokenNumericos;
using Inventario.TI.BackEnd.Repositories.Context;
using Inventario.TI.Core.Exceptions.TokenNumerico;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Repositories
{
    public class TokenNumericoRepository : ITokenNumericoRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenNumericoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TokenNumerico> Inserir(TokenNumerico token)
        {
            var retorno = await _context.TokenNumerico.AddAsync(token);
            _context.SaveChanges();
            return retorno.Entity;
        }
        public async Task<TokenNumerico?> FindByToken(string token)
        {
            var retorno = await Task.Run(() => _context.TokenNumerico.Where(x => x.Token == token).FirstOrDefault());
            return retorno;
        }
        public async Task<bool> UtilizarToken(TokenNumerico token)
        {
            var tokenUtilizado = await _context.TokenNumerico.FirstOrDefaultAsync(x => x.Token == token.Token) ?? throw new TokenNumericoNaoEncontradoException();
            tokenUtilizado.Utilizado = true;

            _context.SaveChanges();
            return true;
        }
        public async Task IncrementarNumeroTentativas(Guid idObjeto)
        {
            var token = await _context.TokenNumerico.FirstOrDefaultAsync(x => x.IdObjeto == idObjeto) ?? throw new TokenNumericoNaoEncontradoException();
            token.NumeroTentativas += 1;
            _context.SaveChanges();
        }
    }
}
