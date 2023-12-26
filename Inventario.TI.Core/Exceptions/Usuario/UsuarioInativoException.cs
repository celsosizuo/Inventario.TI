namespace Inventario.TI.Core.Exceptions.Usuario
{
    public class UsuarioInativoException : Exception
    {
        public UsuarioInativoException() : base("Usuário inativo. Favor efetuar a ativação.")
        {
        }
    }
}
