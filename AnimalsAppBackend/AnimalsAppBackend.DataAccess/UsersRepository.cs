using AnimalsAppBackend.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsAppBackend.DataAccess
{
    public class UsersRepository
    {
        private readonly AnimalsAppDbContext _dbContext;

        public UsersRepository(AnimalsAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
