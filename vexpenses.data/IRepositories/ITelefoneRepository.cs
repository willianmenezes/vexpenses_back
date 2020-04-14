using System;
using System.Threading.Tasks;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface ITelefoneRepository
    {
        Task CadastrarTelefone(Telefone telefone);

        Task<bool> VerificaTelefonePorNumero(string numero, Guid contatoId);
    }
}
