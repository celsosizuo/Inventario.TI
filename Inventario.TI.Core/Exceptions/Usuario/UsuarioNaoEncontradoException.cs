namespace Inventario.TI.Core.Exceptions.Usuario
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException() : base("Usuário ou senha inválidos")
        {
        }
    }
}
