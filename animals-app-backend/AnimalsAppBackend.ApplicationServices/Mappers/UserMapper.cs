using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.Domain;

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
                Phone = user.Phone
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
                Phone = userDto.Phone
            };
        }

        public static void MapUserFromUserDto(User user, UserDto userDto)
        {
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
        }
    }
}
