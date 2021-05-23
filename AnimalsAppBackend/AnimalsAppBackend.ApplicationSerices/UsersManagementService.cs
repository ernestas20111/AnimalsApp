using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Mappers;
using AnimalsAppBackend.ApplicationSerices.Responses;
using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public class UsersManagementService : IUsersManagementService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManagementService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Result<GetUserResponse>> GetUser(Guid id)
        {
            var user = await _usersRepository.Get(id);
            if (user is null)
            {
                return Result<GetUserResponse>.CreateErrorResult($"User with id {id} was not found.");
            }

            return Result<GetUserResponse>.Create(UserMapper.MapGetUserResponseFromUser(user));
        }
    }
}
