namespace Inventario.TI.Core.Exceptions.TokenNumerico
{
    public class TokenNumericoExpiradoException : Exception
    {
        public TokenNumericoExpiradoException() : base("Token expirado. Favor solicitar um novo.")
        {
        }
    }
}
