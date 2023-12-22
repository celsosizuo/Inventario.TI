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
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            
            modelBuilder.Entity<Usuario>(x => x.HasKey(x => x.Id));
            modelBuilder.Entity<Endereco>(x => x.HasKey(x => x.Id));

            modelBuilder.Entity<Empresa>()
                .HasMany(x => x.Usuarios)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.IdEmpresa);

            base.OnModelCreating(modelBuilder);
        }
    }
}
