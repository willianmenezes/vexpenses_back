using System;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models;
using vexpenses.library.Models.Request;

namespace vexpenses.business.Components
{
    public class AgendaComponent
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaComponent(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task CadastrarAgenda(UserClaim user, AgendaRequest request)
        {
            request.Validate();
            user.Validate();

            if (user.PessoaId == Guid.Empty)
            {
                throw new Exception("Dados do usuário não encontrados");
            }

            if (await _agendaRepository.VerificarAgendaPorNome(request.Nome, user.PessoaId))
            {
                throw new Exception("Já existe uma agenda cadastrada com este nome, por favor selecione outro.");
            }

            var agenda = request.ConvertToEntity();
            agenda.PessoaId = user.PessoaId;

            await _agendaRepository.CadastrarAgenda(agenda);
        }
    }
}
