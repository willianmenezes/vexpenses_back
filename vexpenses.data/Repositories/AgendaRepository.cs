using System;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;
using Microsoft.EntityFrameworkCore;
using vexpenses.library.Models;
using vexpenses.library.Models.Response;
using System.Linq;

namespace vexpenses.data.Repositories
{
    public class AgendaRepository : BaseRepository, IAgendaRepository
    {
        public AgendaRepository(VExpensesContext context) : base(context) { }

        public async Task<PagedQueries<Agenda>> BuscarAgendasPaginadas(Guid pessoaId, int pageIndex, int pageSize)
        {
            try
            {
                var query = _context.Agenda
                                    .Include(x => x.TipoAgenda)
                                    .Where(x => x.PessoaId.Equals(pessoaId) && x.Status.Equals(true))
                                    .AsNoTracking();

                return await PagedQueries<Agenda>.Create(query, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar as agendas para o seu usuário", ex);
            }
        }

        public async Task CadastrarAgenda(Agenda agenda)
        {
            try
            {
                await _context.Agenda.AddAsync(agenda);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar agenda", ex);
            }
        }

        public async Task<bool> VerificarAgendaPorNome(string nome, Guid pessoaId)
        {
            try
            {
                return await _context.Agenda.AnyAsync(x => x.Nome.ToLower().Equals(nome.ToLower()) && x.PessoaId.Equals(pessoaId));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar agenda", ex);
            }
        }
    }
}
