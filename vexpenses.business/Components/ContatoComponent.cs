﻿using System;
using System.Threading.Tasks;
using vexpenses.data.IRepositories;
using vexpenses.library.Helpers;
using vexpenses.library.Models.Request;

namespace vexpenses.business.Components
{
    public class ContatoComponent
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoComponent(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task CadastrarContato(ContatoRequest request, TelefoneComponent telefoneComponent, EnderecoComponent enderecoComponent)
        {
            request.Validate();

            if (string.IsNullOrEmpty(request.Nome))
            {
                throw new Exception("O nome do contato é obrigatório.");
            }

            var contato = request.ConvertyToEntity();

            await _contatoRepository.CadastrarContato(contato);

            if (contato.ContatoId == Guid.Empty)
            {
                throw new Exception("Erro ao cadastrar contato, verifique os dados e tente novamente");
            }

            var telefone = request.Telefones;
            var endereco = request.Enderecos;

            await telefoneComponent.CadastrarTelefones(telefone, contato.ContatoId);

            await enderecoComponent.CadastrarEnderecos(endereco, contato.ContatoId);
        }
    }
}
