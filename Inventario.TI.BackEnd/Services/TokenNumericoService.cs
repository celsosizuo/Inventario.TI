using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.TokenNumericos;
using Inventario.TI.Core.Exceptions.TokenNumerico;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Services
{
    public class TokenNumericoService : ITokenNumericoService
    {
        private readonly ITokenNumericoRepository _tokenNumericoRepository;

        public TokenNumericoService(ITokenNumericoRepository tokenNumericoRepository)
        {
            _tokenNumericoRepository = tokenNumericoRepository;
        }

        public async Task<TokenNumerico> Inserir(Guid idExterno)
        {
            var token = new TokenNumerico()
            {
                IdObjeto = idExterno,
                Token = await GerarToken(),
                Utilizado = false,
                NumeroTentativas = 0
            };

            return await _tokenNumericoRepository.Inserir(token);
        }
        public async Task<TokenNumerico?> FindByToken(string token)
        {
            return await _tokenNumericoRepository.FindByToken(token);
        }
        public async Task<bool> UtilizarToken(TokenNumerico token)
        {
            return await _tokenNumericoRepository.UtilizarToken(token);
        }
        public async Task<bool> ValidarToken(Usuario usuario, string tokenDigitado)
        {
            var token = await _tokenNumericoRepository.FindByToken(tokenDigitado) ?? throw new TokenNumericoNaoEncontradoException();
            _ = await VerificarSeTokenPertenceAoUsuario(usuario, token);
            VerificarTempoExpiracaoToken(token.DataCriacao);
            VerificarNumeroDeTentativas(token);

            return true;
        }

        private async Task<bool> VerificarSeTokenPertenceAoUsuario(Usuario usuario, TokenNumerico token)
        {
            if (usuario.IdExterno != token.IdObjeto)
            {
                await _tokenNumericoRepository.IncrementarNumeroTentativas(token.IdObjeto);
                throw new TokenNumericoNaoEncontradoException();
            }
            return true;
        }
        private void VerificarTempoExpiracaoToken(DateTime dataEnvioToken)
        {
            var tempo = dataEnvioToken.Subtract(DateTime.Now);
            if (tempo.Minutes > 30)
                throw new TokenNumericoExpiradoException();
        }
        private void VerificarNumeroDeTentativas(TokenNumerico token)
        {
            if (token.NumeroTentativas > 3)
                throw new TokenNumericoNumeroTentativasExcedidoException();
        }
        private async Task<string> GerarToken()
        {
            Random random = new();
            int numeroAleatorio = await Task.Run(() => random.Next(100000, 999999));
            return numeroAleatorio.ToString();
        }

    }
}
