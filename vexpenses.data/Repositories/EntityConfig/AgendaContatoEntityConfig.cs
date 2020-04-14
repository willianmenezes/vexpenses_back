using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories.EntityConfig
{
    public class AgendaContatoEntityConfig : IEntityTypeConfiguration<AgendaContato>
    {
        public void Configure(EntityTypeBuilder<AgendaContato> builder)
        {
            builder.ToTable("agendacontato");

            builder.HasKey(x => new { x.AgendaId, x.ContatoId });

            builder.Property(x => x.AgendaId)
                    .HasColumnName("agendaid")
                    .IsRequired();

            builder.Property(x => x.ContatoId)
                    .HasColumnName("contatoid")
                    .IsRequired();

            builder.HasOne(x => x.Agenda)
                    .WithMany(x => x.AgendaContato)
                    .HasForeignKey(x => x.AgendaId)
                    .HasConstraintName("agendacontato_agenda_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Contato)
                    .WithMany(x => x.AgendaContato)
                    .HasForeignKey(x => x.ContatoId)
                    .HasConstraintName("agendacontato_contato_fk")
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
