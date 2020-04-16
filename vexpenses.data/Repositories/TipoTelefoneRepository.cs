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
    public class TipoTelefoneRepository : BaseRepository, ITipoTelefoneRepository
    {
        public TipoTelefoneRepository(VExpensesContext context) : base(context) { }

        public async Task<IEnumerable<TipoTelefone>> BuscarTiposTelefone()
        {
            try
            {
                return await _context.TipoTelefone.OrderBy(x => x.Descricao).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar tipos de telefone");
            }
        }
    }
}
