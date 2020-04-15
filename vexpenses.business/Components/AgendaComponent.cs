using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models;
using vexpenses.library.Models.Request;
using vexpenses.library.Models.Response;

namespace vexpenses.business.Components
{
    public class AgendaComponent
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AgendaComponent(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
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

        public async Task<PaginationResponse<AgendaResponse>> BuscarAgendasPaginadas(Guid pessoaId, int pageIndex = 1, int pageSize = 10)
        {
            if (pessoaId == Guid.Empty)
            {
                throw new ArgumentNullException("ID da do usuário não fornecido para esta operação");
            }

            var query = await _agendaRepository.BuscarAgendasPaginadas(pessoaId, pageIndex, pageSize);
            var agendas = _mapper.Map<List<AgendaResponse>>(query);

            return new PaginationResponse<AgendaResponse>
            {
                ItemsList = agendas,
                PageIndex = query.PageIndex,
                TotalItens = query.TotalItens,
                TotalPages = query.TotalPages
            };
        }
    }
}
