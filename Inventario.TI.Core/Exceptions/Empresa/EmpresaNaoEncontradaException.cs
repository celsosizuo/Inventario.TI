namespace Inventario.TI.Core.Exceptions.Empresa
{
    public class EmpresaNaoEncontradaException : Exception
    {
        public EmpresaNaoEncontradaException() : base("Empresa não encontrada")
        {
        }
    }
}
