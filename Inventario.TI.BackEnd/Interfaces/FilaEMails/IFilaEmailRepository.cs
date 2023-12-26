using Inventario.TI.BackEnd.Entities;

namespace Inventario.TI.BackEnd.Interfaces.FilaEMails
{
    public interface IFilaEmailRepository
    {
        Task Inserir(FilaEMail model);
        Task Reprocessar(FilaEMail model);
    }
}
