using System;
using System.Threading.Tasks;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface IAgendaRepository
    {
        Task CadastrarAgenda(Agenda agenda);

        Task<bool> VerificarAgendaPorNome(string nome, Guid pessoaId);
    }
}
