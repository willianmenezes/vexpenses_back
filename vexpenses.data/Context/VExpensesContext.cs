using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using vexpenses.data.Repositories.EntityConfig;
using vexpenses.library.Entities;

namespace vexpenses.data.Context
{
    public class VExpensesContext: DbContext
    {
        private IConfiguration configuration;

        public VExpensesContext()
        {
        }

        public VExpensesContext(DbContextOptions<VExpensesContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<AgendaContato> AgendaContato { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<TipoAgenda> TipoAgenda { get; set; }
        public virtual DbSet<TipoTelefone> TipoTelefone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("vexpenses"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.3-servicing-10062");

            modelBuilder.HasPostgresExtension("uuid - ossp");

            modelBuilder.ApplyConfiguration(new AgendaEntityConfig());
            modelBuilder.ApplyConfiguration(new AgendaContatoEntityConfig());
            modelBuilder.ApplyConfiguration(new ContatoEntityConfig());
            modelBuilder.ApplyConfiguration(new EnderecoEntityConfig());
            modelBuilder.ApplyConfiguration(new PessoaEntitConfig());
            modelBuilder.ApplyConfiguration(new RefreshTokenEntityConfig());
            modelBuilder.ApplyConfiguration(new TelefoneEntityConfig());
            modelBuilder.ApplyConfiguration(new TipoAgendaEntityConfig());
            modelBuilder.ApplyConfiguration(new TipoTelefoneEntityConfig());
        }
    }
}
