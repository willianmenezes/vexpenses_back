using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models.Request;

namespace vexpenses.business.Components
{
    public class TelefoneComponent
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneComponent(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public async Task CadastrarTelefones(List<TelefoneRequest> telefones, Guid contatoId)
        {
            foreach (var request in telefones)
            {
                request.Validate();

                if (contatoId == Guid.Empty)
                {
                    throw new Exception("Id do contato não fornecidado para o cadastro.");
                }

                if (request.TipoTelefoneId == Guid.Empty)
                {
                    throw new Exception("Id do tipo de telefone não fornecidado para o cadastro.");
                }

                if (await _telefoneRepository.VerificaTelefonePorNumero(request.Numero, contatoId))
                {
                    throw new Exception($"Já existe um número de telefone semelhante ao ({request.DDD}) {request.Numero}, cadastrado para este contato.");
                }

                var telefone = request.ConvertyToEntity();
                telefone.ContatoId = contatoId;

                await _telefoneRepository.CadastrarTelefone(telefone);

                if (telefone.TelefoneId == Guid.Empty)
                {
                    throw new Exception($"Erro ao cadastrar telefone de numero: ({telefone.DDD}) {telefone.Numero}");
                }
            }
        }
    }
}
