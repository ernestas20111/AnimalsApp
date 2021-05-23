using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppBackend.Domain
{
    public class User : DomainEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}