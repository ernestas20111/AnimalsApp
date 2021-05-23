using AnimalsAppBackend.Domain;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.DataAccess
{
    public interface IUsersRepository
    {
        Task SaveChanges();

        Task<User> Get(Guid id);
    }
}