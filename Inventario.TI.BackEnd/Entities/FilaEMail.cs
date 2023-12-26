using Inventario.TI.BackEnd.Enum;

namespace Inventario.TI.BackEnd.Entities
{
    public class FilaEMail : EntityBase
    {
        public DateTime? DataEnvio { get; set; }
        public required StatusFilaEmail Status { get; set; }
        public required string Destinatario { get; set; }
        public required string Assunto { get; set; }
        public required string Mensagem { get; set; }
        public virtual Empresa? Empresa { get; set; }
        public long IdEmpresa { get; set; }
    }
}
