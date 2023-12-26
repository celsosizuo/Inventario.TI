using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.FilaEMails;
using Inventario.TI.BackEnd.Repositories.Context;

namespace Inventario.TI.BackEnd.Repositories
{
    public class FilaEmailRepository : IFilaEmailRepository
    {
        private readonly ApplicationDbContext _context;

        public FilaEmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Inserir(FilaEMail model)
        {
            await _context.FilaEmails.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task Reprocessar(FilaEMail model)
        {
            var fila = _context.FilaEmails.FirstOrDefault(x => x.Id == model.Id) ?? throw new ArgumentNullException(model.Id.ToString());
            fila.Status = Enum.StatusFilaEmail.Pendente;
            _context.SaveChanges();
        }
    }
}
