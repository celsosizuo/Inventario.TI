namespace Inventario.TI.BackEnd.Entities
{
    public class Empresa : EntityBase
    {
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public bool Ativo { get; set; }
        public int IdEndereco { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }
        public virtual ICollection<FilaEMail>? FilaEmails { get; set; }
        public virtual Endereco? Endereco { get; set; }
    }
}
