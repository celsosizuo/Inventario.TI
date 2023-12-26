using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.FilaEMails;

namespace Inventario.TI.BackEnd.Services
{
    public class FilaEMailService : IFilaEmailService
    {
        private readonly IFilaEmailRepository _filaEmailrepository;

        public FilaEMailService(IFilaEmailRepository filaEmailrepository)
        {
            _filaEmailrepository = filaEmailrepository;
        }

        public async Task Inserir(FilaEMail model)
        {
            await _filaEmailrepository.Inserir(model);
        }

        public async Task Reprocessar(FilaEMail model)
        {
            await _filaEmailrepository.Reprocessar(model);
        }
    }
}
