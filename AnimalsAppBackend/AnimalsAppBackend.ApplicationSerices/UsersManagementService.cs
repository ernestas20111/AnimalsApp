using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Mappers;
using AnimalsAppBackend.ApplicationSerices.Responses;
using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public class UsersManagementService
    {
        private readonly UsersRepository _usersRepository;

        public UsersManagementService(UsersRepository usersRepository)
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
