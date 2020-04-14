using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.business.Components
{
    public class TipoAgendaComponent
    {
        private readonly ITipoAgendaRepository _tipoAgendaRepository;
        public TipoAgendaComponent(ITipoAgendaRepository tipoAgendaRepository)
        {
            _tipoAgendaRepository = tipoAgendaRepository;
        }

        public async Task<IEnumerable<TipoAgenda>> BuscarTiposAgenda()
        {

            return await _tipoAgendaRepository.BuscarTiposAgenda();
        }
    }
}
