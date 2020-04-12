using System;
using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface IRefreshTokenRepository
    {
        void SetRefreshToken(RefreshToken refreshtoken);

        RefreshToken GetRefreshToken(Guid Nidpessoa);
    }
}
