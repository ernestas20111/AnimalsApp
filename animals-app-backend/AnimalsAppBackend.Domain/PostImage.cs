using System;

namespace AnimalsAppBackend.Domain
{
    public class PostImage : IDomainEntity
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }

        public string ImageUrl { get; set; }
    }
}