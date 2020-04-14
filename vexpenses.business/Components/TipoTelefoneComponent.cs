using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.business.Components
{
    public class TipoTelefoneComponent
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        public TipoTelefoneComponent(ITipoTelefoneRepository tipoTelefoneRepository)
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;
        }

        public async Task<IEnumerable<TipoTelefone>> BuscarTiposTelefone(){

            return await _tipoTelefoneRepository.BuscarTiposTelefone();
        }
    }
}
