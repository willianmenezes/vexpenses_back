using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VExpensesContext _context;

        public UserRepository(VExpensesContext context)
        {
            _context = context;
        }

        public Pessoa GetByLogin(string login)
        {
            try
            {
                return _context.Pessoa.AsNoTracking().FirstOrDefault(x => x.Email.Equals(login));
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar a pessoa por id.", ex);
            }
        }
    }
}
