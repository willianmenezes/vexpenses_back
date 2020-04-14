using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TipoTelefone>> BuscarTiposTelefone();
    }
}
