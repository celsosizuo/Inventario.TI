using Inventario.TI.BackEnd.DTO;
using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Interfaces.Usuarios;
using Inventario.TI.BackEnd.Repositories.Context;
using Inventario.TI.Core.Exceptions.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Inserir(Usuario usuario)
        {
            var retorno = await _context.Usuarios.AddAsync(usuario);
            _context.SaveChanges();
            return retorno.Entity;
        }
        public async Task<bool> Alterar(Usuario usuario)
        {
            var retorno = await Task.Run(() => _context.Usuarios.Update(usuario));
            _context.SaveChanges();
            return retorno != null;
        }
        public async Task<Usuario?> FindById(long id)
        {
            var retorno = await Task.Run(() => _context.Usuarios.Where(x => x.Id == id).FirstOrDefault());
            return retorno;
        }
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario?> GetByIdExterno(Guid idExterno)
        {
            var retorno = await Task.Run(() => _context.Usuarios.Where(x => x.IdExterno == idExterno).FirstOrDefault());
            return retorno;
        }
        public async Task<Usuario?> GetByLogin(string login)
        {
            var retorno = await Task.Run(() => _context.Usuarios.Where(x => x.Login == login).FirstOrDefault());
            return retorno;
        }
        public async Task<bool> Ativar(Guid idExterno)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdExterno == idExterno) ?? throw new UsuarioNaoEncontradoException();

            usuario.Ativo = true;
            _context.SaveChanges();

            return true;
        }
        public async Task<bool> AlterarSenha(DtoAlterarSenha model)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.IdExterno == model.IdExterno) ?? throw new UsuarioNaoEncontradoException();

            usuario.Senha = model.Senha;
            usuario.Ativo = true;

            _context.SaveChanges();

            return true;
        }
    }
}
