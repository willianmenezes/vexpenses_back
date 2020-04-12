using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    class EnderecoEntityConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(x => x.EnderecoId);

            builder.Property(x => x.EnderecoId)
                    .HasColumnName("enderecoid")
                    .IsRequired();

            builder.Property(x => x.ContatoId)
                    .HasColumnName("contatoid")
                    .IsRequired();

            builder.Property(x => x.Status)
                    .HasColumnName("status")
                    .IsRequired();

            builder.Property(x => x.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsRequired();

            builder.Property(x => x.Bairro)
                   .HasColumnName("bairro")
                   .HasMaxLength(200)
                   .IsUnicode(false);


            builder.Property(x => x.Complemento)
                   .HasColumnName("complemento")
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(x => x.Localidade)
                   .HasColumnName("localidade")
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(x => x.Logradouro)
                   .HasColumnName("logradouro")
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(x => x.Uf)
                  .HasColumnName("uf")
                  .HasMaxLength(200)
                  .IsUnicode(false);

            builder.HasOne(x => x.Contato)
                    .WithMany(x => x.Endereco)
                    .HasForeignKey(x => x.ContatoId)
                    .HasConstraintName("endereco_contato_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
