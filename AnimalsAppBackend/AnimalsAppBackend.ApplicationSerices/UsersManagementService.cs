using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Mappers;
using AnimalsAppBackend.ApplicationSerices.Responses;
using AnimalsAppBackend.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public class UsersManagementService : IUsersManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetAllUsersResponse>> GetAllUsers()
        {
            var users = await _unitOfWork.Users.GetAll().ToListAsync();
            if (users is null)
            {
                return Result<GetAllUsersResponse>.CreateErrorResult($"No users were found.");
            }

            return Result<GetAllUsersResponse>.Create(UserMapper.MapGetAllUsersResponseFromUsers(users));
        }

        public async Task<Result<GetUserResponse>> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            if (user is null)
            {
                return Result<GetUserResponse>.CreateErrorResult($"User with id {id} was not found.");
            }

            return Result<GetUserResponse>.Create(UserMapper.MapGetUserResponseFromUser(user));
        }
    }
}
