using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppBackend.Domain
{
    public class User : IDomainEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}