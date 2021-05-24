using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationServices.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
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
