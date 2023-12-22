using Inventario.TI.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.TI.BackEnd.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Rua)
                .HasMaxLength(300);

            builder.Property(x => x.Numero)
                .HasMaxLength(50);

            builder.Property(x => x.Complemento)
                .HasMaxLength(100);

            builder.Property(x => x.Bairro)
                .HasMaxLength(100);

            builder.Property(x => x.Cidade)
                .HasMaxLength(100);

            builder.Property(x => x.Estado)
                .HasMaxLength(2);

            builder.Property(x => x.Cep)
                .HasMaxLength(8);
        }
    }
}
