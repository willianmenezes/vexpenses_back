using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class RefreshTokenEntityConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {

            builder.ToTable("refreshtoken");

            builder.HasKey(x => x.PessoaId);

            builder.Property(x => x.PessoaId)
                    .HasColumnName("pessoaid")
                    .IsRequired();

            builder.Property(x => x.Token)
                    .HasColumnName("token")
                    .HasMaxLength(500)
                    .IsUnicode(false);

            builder.Property(x => x.Expiracao)
                   .HasColumnName("expiracao")
                   .HasMaxLength(50)
                   .IsUnicode(false);
        }
    }
}
