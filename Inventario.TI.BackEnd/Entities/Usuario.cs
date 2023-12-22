namespace Inventario.TI.BackEnd.Entities
{
    public class Usuario : EntityBase
    {
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
    }
}
