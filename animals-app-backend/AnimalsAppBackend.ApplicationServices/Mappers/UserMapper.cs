using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationServices.Requests;
using AnimalsAppBackend.ApplicationServices.Responses;
using AnimalsAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapUserDtoFromUser(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
        }

        public static User MapUserFromUserDto(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash,
                PasswordSalt = userDto.PasswordSalt
            };
        }

        public static void MapUserFromUserDto(User user, UserDto userDto)
        {
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Email = userDto.Email;
            user.PasswordHash = userDto.PasswordHash;
            user.PasswordSalt = userDto.PasswordSalt;
        }
    }
}
