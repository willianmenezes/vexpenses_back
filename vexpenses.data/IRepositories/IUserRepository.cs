using vexpenses.library.Entities;

namespace vexpenses.data.IRepositories
{
    public interface IUserRepository
    {
        Pessoa GetByLogin(string login);
    }
}
