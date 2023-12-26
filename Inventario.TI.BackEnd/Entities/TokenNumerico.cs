namespace Inventario.TI.BackEnd.Entities
{
    public class TokenNumerico : EntityBase
    {
        public string Token { get; set; }
        public int NumeroTentativas { get; set; }
        public bool Utilizado { get; set; }
        public Guid IdObjeto { get; set; }
    }
}
