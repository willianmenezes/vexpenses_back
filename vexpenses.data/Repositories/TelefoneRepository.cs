using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class TelefoneRepository : BaseRepository, ITelefoneRepository
    {

        public TelefoneRepository(VExpensesContext context) : base(context) { }

        public async Task CadastrarTelefone(Telefone telefone)
        {
            try
            {
                await _context.Telefone.AddAsync(telefone);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar telefone", ex);
            }
        }

        public async Task<bool> VerificaTelefonePorNumero(string numero, Guid contatoId)
        {
            return await _context.Telefone.AnyAsync(x => x.Numero.Equals(numero) && x.ContatoId.Equals(contatoId));
        }
    }
}
