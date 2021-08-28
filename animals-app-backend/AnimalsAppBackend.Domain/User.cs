using System;
using System.Collections.Generic;

namespace AnimalsAppBackend.Domain
{
    public class User : IDomainEntity
    {
        public Guid Id { get; set; }

        public UserDetails UserDetails { get; set; }

        public List<Post> Posts { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}