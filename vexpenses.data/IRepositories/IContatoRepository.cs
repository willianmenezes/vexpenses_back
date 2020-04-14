using System.Threading.Tasks;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface IContatoRepository
    {
        Task CadastrarContato(Contato contato);
    }
}
