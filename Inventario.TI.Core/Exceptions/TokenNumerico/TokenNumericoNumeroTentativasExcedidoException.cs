namespace Inventario.TI.Core.Exceptions.TokenNumerico
{
    public class TokenNumericoNumeroTentativasExcedidoException : Exception
    {
        public TokenNumericoNumeroTentativasExcedidoException() : base("Número de tentativas de utilização do token excedido. Favor solicitar um novo.")
        {
        }
    }
}
