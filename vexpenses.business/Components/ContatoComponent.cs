using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models.Request;
using vexpenses.library.Models.Response;

namespace vexpenses.business.Components
{
    public class ContatoComponent
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
        public ContatoComponent(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task CadastrarContato(ContatoRequest request, TelefoneComponent telefoneComponent, EnderecoComponent enderecoComponent, EmailComponent emailComponent)
        {
            request.Validate();

            if (string.IsNullOrEmpty(request.Nome))
            {
                throw new Exception("O nome do contato é obrigatório.");
            }

            if (request.AgendaId == Guid.Empty)
            {
                throw new Exception("ID da agenda não fornecido para realizar o cadastro.");
            }

            var contato = request.ConvertyToEntity();

            await _contatoRepository.CadastrarContato(contato, request.AgendaId);

            if (contato.ContatoId == Guid.Empty)
            {
                throw new Exception("Erro ao cadastrar contato, verifique os dados e tente novamente");
            }

            var telefone = request.Telefones;
            var endereco = request.Enderecos;

            await telefoneComponent.CadastrarTelefones(telefone, contato.ContatoId);

            await enderecoComponent.CadastrarEnderecos(endereco, contato.ContatoId);

            if (!string.IsNullOrWhiteSpace(contato.Email))
            {
                await emailComponent.EnviarEmailContato(contato, contato.Email);
            }
        }

        public async Task<List<ContatoResponse>> BuscarContatosPorAgenda(Guid agendaId)
        {
            if (agendaId == Guid.Empty)
            {
                throw new Exception("ID da agenda não fornecido");
            }

            var contatos = await _contatoRepository.BuscarContatosPorAgenda(agendaId);

            return _mapper.Map<List<ContatoResponse>>(contatos);
        }
    }
}
