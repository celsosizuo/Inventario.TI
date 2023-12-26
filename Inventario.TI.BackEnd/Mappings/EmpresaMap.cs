using Inventario.TI.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.TI.BackEnd.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Cnpj)
                .IsRequired();

            builder.Property(x => x.RazaoSocial)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IdExterno)
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.IdUsuarioCriacao)
                .IsRequired();
        }
    }
}
