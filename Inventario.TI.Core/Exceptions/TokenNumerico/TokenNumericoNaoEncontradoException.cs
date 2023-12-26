namespace Inventario.TI.Core.Exceptions.TokenNumerico
{
    public class TokenNumericoNaoEncontradoException : Exception
    {
        public TokenNumericoNaoEncontradoException() : base("Token não encontrado")
        {
        }
    }
}
