using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class TipoTelefoneEntityConfig : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("tipotelefone");

            builder.HasKey(x => x.TipoTelefoneId);

            builder.Property(x => x.TipoTelefoneId)
                    .HasColumnName("tipotelefoneid")
                    .IsRequired();

            builder.Property(x => x.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .IsRequired();
        }
    }
}
