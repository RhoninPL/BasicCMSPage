using Domain;
using Repositories.IRepository.BaseRepository;

namespace Repositories.IRepository
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        Users FindByName(string name);
    }
}