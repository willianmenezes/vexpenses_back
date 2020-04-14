using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models.Request;

namespace vexpenses.business.Components
{
    public class EnderecoComponent
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoComponent(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task CadastrarEnderecos(List<EnderecoRequest> enderecos, Guid contatoId)
        {
            foreach (var request in enderecos)
            {
                request.Validate();
                

                if (contatoId == Guid.Empty)
                {
                    throw new Exception("Id do contato não fornecidado para o cadastro.");
                }

                if (string.IsNullOrEmpty(request.Cep))
                {
                    throw new Exception("CEP não fornecido para cadastro de endereço.");
                }

                var endereco = request.ConvertyToEntity();
                endereco.ContatoId = contatoId;

                await _enderecoRepository.CadastrarEndereco(endereco);

                if (endereco.EnderecoId == Guid.Empty)
                {
                    throw new Exception($"Erro ao cadastrar endereço de CEP {endereco.Cep}");
                }
            }
        }
    }
}
