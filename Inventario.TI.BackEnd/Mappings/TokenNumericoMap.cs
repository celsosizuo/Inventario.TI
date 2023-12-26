using Inventario.TI.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.TI.BackEnd.Mappings
{
    public class TokenNumericoMap : IEntityTypeConfiguration<TokenNumerico>
    {
        public void Configure(EntityTypeBuilder<TokenNumerico> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.IdUsuarioCriacao) 
                .IsRequired();

            builder.Property(x => x.Token)
                .IsRequired();

            builder.Property(x => x.NumeroTentativas)
                .IsRequired();

            builder.Property(x => x.DataCriacao) 
                .IsRequired();
        }
    }
}
