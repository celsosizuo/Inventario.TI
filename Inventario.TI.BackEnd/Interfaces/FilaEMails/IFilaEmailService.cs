using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.FilaEMails
{
    public interface IFilaEmailService
    {
        Task Inserir(FilaEMail model);
        Task Reprocessar(FilaEMail model);
    }
}
