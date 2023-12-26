using Inventario.TI.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.TI.BackEnd.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.IdExterno)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Role)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.IdUsuarioCriacao)
                .IsRequired();
        }
    }
}
