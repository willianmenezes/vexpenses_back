using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class TipoAgendaRepository : BaseRepository, ITipoAgendaRepository
    {
        public TipoAgendaRepository(VExpensesContext context) : base(context) { }

        public async Task<IEnumerable<TipoAgenda>> BuscarTiposAgenda()
        {
            try
            {
                return await _context.TipoAgenda.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar os tipos de agenda.", ex);
            }
        }
    }
}
