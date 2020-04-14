using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class AgendaContatoRepository : BaseRepository, IAgendaContatoRepository
    {
        public AgendaContatoRepository(VExpensesContext context) : base(context) { }
        public async Task CadastrarAgendaContato(AgendaContato agendaContato)
        {
            try
            {
                await _context.AgendaContato.AddAsync(agendaContato);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar agenda/contato", ex);
            }
        }
    }
}
