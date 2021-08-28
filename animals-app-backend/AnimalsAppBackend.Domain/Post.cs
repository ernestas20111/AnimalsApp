using System;
using System.Collections.Generic;

namespace AnimalsAppBackend.Domain
{
    public class Post : IDomainEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public List<PostImage> PostImages { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public DateTime Duration { get; set; }

        public string Category { get; set; }

        public string Purpose { get; set; }
    }
}