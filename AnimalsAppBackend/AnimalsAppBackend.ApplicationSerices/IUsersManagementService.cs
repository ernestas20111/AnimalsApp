using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationSerices.Responses;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices
{
    public interface IUsersManagementService
    {
        Task<Result<GetUserResponse>> GetUser(Guid id);
    }
}
