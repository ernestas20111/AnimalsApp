using AnimalsAppBackend.Abstractions;
using System;

namespace AnimalsAppBackend.ApplicationServices.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [EmailValidation]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
