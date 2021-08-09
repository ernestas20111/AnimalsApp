using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppBackend.Domain
{
    public class UserDetails : IDomainEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public string Role { get; set; }

        public bool Verified { get; set; }
    }
}