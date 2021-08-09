using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsAppBackend.Domain
{
    public class PostImage : IDomainEntity
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public string ImageUrl { get; set; }
    }
}