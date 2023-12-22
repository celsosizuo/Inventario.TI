using Inventario.TI.BackEnd.Entities;
using Inventario.TI.BackEnd.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Inventario.TI.BackEnd.Repositories.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        #region DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.Entity<Usuario>(x => x.HasKey(x => x.Id));

            base.OnModelCreating(modelBuilder);
        }

    }
}
