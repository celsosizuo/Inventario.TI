using Inventario.TI.BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.TI.BackEnd.Mappings
{
    public class FilaEMailMap : IEntityTypeConfiguration<FilaEMail>
    {
        public void Configure(EntityTypeBuilder<FilaEMail> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.IdUsuarioCriacao)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Destinatario)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Assunto)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Mensagem)
                .HasMaxLength(8000)
                .IsRequired();
        }
    }
}
