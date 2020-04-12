using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class TipoAgendaEntityConfig : IEntityTypeConfiguration<TipoAgenda>
    {
        public void Configure(EntityTypeBuilder<TipoAgenda> builder)
        {
            builder.ToTable("tipoagenda");

            builder.HasKey(x => x.TipoAgendaId);

            builder.Property(x => x.TipoAgendaId)
                    .HasColumnName("tipoagendaid")
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
