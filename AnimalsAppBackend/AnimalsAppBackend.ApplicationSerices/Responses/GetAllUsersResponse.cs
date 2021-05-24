using AnimalsAppBackend.ApplicationSerices.Responses;
using System.Collections.Generic;

namespace AnimalsAppBackend.ApplicationSerices
{
    public class GetAllUsersResponse
    {
        public IEnumerable<GetUserResponse> Users { get; set; }
    }
}