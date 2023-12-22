using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Inventario.TI.BackEnd.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ApplicationDbContext _context;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> Inserir(Empresa empresa)
        {
            var retorno = await _context.Empresas.AddAsync(empresa);
            _context.SaveChanges();
            return retorno.Entity;
        }
        public async Task<bool> Alterar(Empresa empresa)
        {
            var retorno = await Task.Run(() => _context.Empresas.Update(empresa));
            _context.SaveChanges();
            return retorno != null;
        }
        public async Task<Empresa?> FindById(long id)
        {
            var retorno = await Task.Run(() => _context.Empresas.Where(x => x.Id == id).FirstOrDefault());
            return retorno;
        }
        public async Task<IEnumerable<Empresa>> Get()
        {
            return await _context.Empresas.ToListAsync();
        }
        public async Task<Empresa?> GetByIdExterno(Guid idExterno)
        {
            var retorno = await Task.Run(() => _context.Empresas.Where(x => x.IdExterno == idExterno).FirstOrDefault());
            return retorno;
        }
    }
}
