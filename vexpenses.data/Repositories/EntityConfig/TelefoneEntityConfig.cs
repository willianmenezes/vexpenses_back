using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class TelefoneEntityConfig : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("telefone");

            builder.HasKey(x => x.TelefoneId);

            builder.Property(x => x.TelefoneId)
                    .HasColumnName("telefoneid")
                    .IsRequired();

            builder.Property(x => x.DDD)
                    .HasColumnName("ddd")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.ContatoId)
                   .HasColumnName("contatoid")
                   .IsRequired();

            builder.Property(x => x.TipoTelefoneId)
                   .HasColumnName("tipotelefoneid")
                   .IsRequired();

            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.HasOne(x => x.Contato)
                    .WithMany(x => x.Telefone)
                    .HasForeignKey(x => x.ContatoId)
                    .HasConstraintName("telefone_contato_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.TipoTelefone)
                    .WithMany(x => x.Telefone)
                    .HasForeignKey(x => x.TipoTelefoneId)
                    .HasConstraintName("telefone_tipotelefone_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
