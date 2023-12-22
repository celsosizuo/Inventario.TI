using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Models
{
    public class ContaModel
    {
        public required Empresa Empresa { get; set; }
        public required Usuario Usuario { get; set; }
    }
}
