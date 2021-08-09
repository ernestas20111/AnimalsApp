using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
{
    public interface IUserDetailsManagementService
    {
        Task<Result<UserDetailsDto>> GetUserDetails(Guid id);

        Task<Result<UserDetailsDto>> AddUserDetails(UserDetailsDto userDetailsDto);

        Task<Result<string>> UpdateUserDetails(UserDetailsDto userDetailsDto);

        Task<Result<string>> RemoveUserDetails(Guid id);
    }
}
