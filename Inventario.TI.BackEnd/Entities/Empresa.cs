namespace Inventario.TI.BackEnd.Entities
{
    public class Empresa : EntityBase
    {
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public int IdEndereco { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
