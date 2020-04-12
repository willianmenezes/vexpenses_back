using System;
using System.Linq;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly VExpensesContext _context;

        public RefreshTokenRepository(VExpensesContext context)
        {
            _context = context;
        }

        public void SetRefreshToken(RefreshToken refreshtoken)
        {
            try
            {
                var refresh = _context.RefreshToken.FirstOrDefault(x => x.PessoaId == refreshtoken.PessoaId);

                if (refresh != null)
                {
                    refresh.Token = refreshtoken.Token;
                    refresh.Expiracao = refreshtoken.Expiracao;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel salvar o refresh token.", ex);
            }
        }

        public RefreshToken GetRefreshToken(Guid Nidpessoa)
        {
            try
            {
                return _context.RefreshToken.FirstOrDefault(x => x.PessoaId == Nidpessoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel encontrar o refresh token.", ex);
            }
        }
    }
}
