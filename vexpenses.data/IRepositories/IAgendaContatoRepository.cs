using System;
using System.Threading.Tasks;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface IAgendaContatoRepository
    {
        Task CadastrarAgendaContato(AgendaContato agendaContato);
    }
}
