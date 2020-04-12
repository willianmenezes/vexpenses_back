using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class PessoaEntitConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(x => x.PessoaId);

            builder.Property(x => x.PessoaId)
                    .HasColumnName("pessoaid")
                    .IsRequired();

            builder.Property(x => x.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();
        }
    }
}
