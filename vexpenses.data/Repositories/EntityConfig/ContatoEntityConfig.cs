using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    class ContatoEntityConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("contato");

            builder.HasKey(x => x.ContatoId);

            builder.Property(x => x.ContatoId)
                    .HasColumnName("contatoid")
                    .IsRequired();

            builder.Property(x => x.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Sobrenome)
                   .HasColumnName("sobrenome")
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .IsRequired();
        }
    }
}
