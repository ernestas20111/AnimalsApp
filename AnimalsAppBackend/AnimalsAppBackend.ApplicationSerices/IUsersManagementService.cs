using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Dtos;
using AnimalsAppBackend.ApplicationSerices.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public interface IUsersManagementService
    {
        Task<Result<UserDto>> GetUser(Guid id);

        Task<Result<List<UserDto>>> GetAllUsers();

        Task<Result<UserDto>> AddUser(UserDto userDto);

        Task<Result<string>> UpdateUser(UserDto userDto);

        Task<Result<string>> RemoveUser(Guid id);
    }
}
