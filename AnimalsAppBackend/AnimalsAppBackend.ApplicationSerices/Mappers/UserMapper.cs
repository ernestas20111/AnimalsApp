using AnimalsAppBackend.ApplicationSerices.Responses;
using AnimalsAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationSerices.Mappers
{
    public static class UserMapper
    {
        public static GetUserResponse MapGetUserResponseFromUser(User user)
        {
            return new GetUserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
        }
    }
}
