using AnimalsAppBackend.Abstractions;
using System;

namespace AnimalsAppBackend.ApplicationServices.Dtos
{
    public class PostImageDto
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public string ImageUrl { get; set; }
    }
}
