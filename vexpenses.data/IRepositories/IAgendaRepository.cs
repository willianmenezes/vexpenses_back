using System;
using System.Threading.Tasks;
using vexpenses.library.Entities;
using vexpenses.library.Models;

namespace vexpenses.data.IRepositories
{
    public interface IAgendaRepository
    {
        Task CadastrarAgenda(Agenda agenda);

        Task<bool> VerificarAgendaPorNome(string nome, Guid pessoaId);

        Task<PagedQueries<Agenda>> BuscarAgendasPaginadas(Guid pessoaId, int pageIndex, int pageSize);

        Task ExcluirAgenda(Guid agendaId, Guid pessoaId);

    }
}
