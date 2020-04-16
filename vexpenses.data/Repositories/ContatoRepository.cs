using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class ContatoRepository : BaseRepository, IContatoRepository
    {
        public ContatoRepository(VExpensesContext context) : base(context) { }

        public async Task<List<Contato>> BuscarContatosPorAgenda(Guid agendaId)
        {
            return await _context.Contato
                                .Include(x => x.AgendaContato)
                                 .Include(x => x.Endereco)
                                 .Include(x => x.Telefone)
                                .Where(x => x.AgendaContato.Select(x => x.AgendaId).Contains(agendaId) && x.Status.Equals(true))
                                .OrderBy(x => x.Nome)
                                .ToListAsync();
        }

        public async Task CadastrarContato(Contato contato, Guid agendaId)
        {
            try
            {
                await _context.Contato.AddAsync(contato);
                await _context.AgendaContato.AddAsync(new AgendaContato { AgendaId = agendaId, ContatoId = contato.ContatoId });
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar contato", ex);
            }
        }

        public async Task ExcluirContato(Guid contatoId)
        {
            try
            {
                var contato = await _context.Contato.FirstOrDefaultAsync(x => x.ContatoId.Equals(contatoId));
                contato.Status = false;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir agenda", ex);
            }
        }
    }
}
