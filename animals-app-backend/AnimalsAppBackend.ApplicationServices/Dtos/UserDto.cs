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

        [PhoneValidation]
        public string Phone { get; set; }
    }
}
