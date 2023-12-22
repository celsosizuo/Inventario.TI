namespace Inventario.TI.BackEnd.Entities
{
    public class EntityBase
    {
        internal long Id { get; set; }
        internal Guid IdExterno { get; set; }
        internal DateTime DataCriacao { get; set; } = DateTime.Now;
        internal long IdUsuarioCriacao { get; set; }
    }
}