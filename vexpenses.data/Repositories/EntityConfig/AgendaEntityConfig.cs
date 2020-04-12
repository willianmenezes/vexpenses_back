using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class AgendaEntityConfig : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("agenda");

            builder.HasKey(x => x.AgendaId);

            builder.Property(x => x.AgendaId)
                    .HasColumnName("agendaid")
                    .IsRequired();

            builder.Property(x => x.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(400)
                    .IsUnicode(false);

            builder.Property(x => x.TipoAgendaId)
                   .HasColumnName("tipoagendaid")
                   .IsRequired();

            builder.Property(x => x.PessoaId)
                   .HasColumnName("pessoaid")
                   .IsRequired();

            builder.HasOne(x => x.Pessoa)
                    .WithMany(x => x.Agenda)
                    .HasForeignKey(x => x.PessoaId)
                    .HasConstraintName("agenda_pessoaid_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.TipoAgenda)
                    .WithMany(x => x.Agenda)
                    .HasForeignKey(x => x.TipoAgendaId)
                    .HasConstraintName("agenda_tipoagenda_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
