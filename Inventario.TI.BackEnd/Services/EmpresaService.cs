using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Empresas;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        
        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<Empresa> Inserir(Empresa empresa)
        {
            return await _empresaRepository.Inserir(empresa);
        }
        public async Task<bool> Alterar(Empresa empresa)
        {
            return await _empresaRepository.Alterar(empresa);
        }
        public async Task<Empresa?> FindById(long id)
        {
            return await _empresaRepository.FindById(id);
        }
        public async Task<IEnumerable<Empresa>> Get()
        {
            return await _empresaRepository.Get();
        }
        public async Task<Empresa?> GetByIdExterno(Guid idExterno)
        {
            return await _empresaRepository.GetByIdExterno(idExterno);
        }
        public async Task<bool> Ativar(Guid idExterno)
        {
            return await _empresaRepository.Ativar(idExterno);
        }
    }
}
