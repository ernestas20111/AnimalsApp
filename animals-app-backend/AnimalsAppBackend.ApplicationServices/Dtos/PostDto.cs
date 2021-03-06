using System;

namespace AnimalsAppBackend.ApplicationServices.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public DateTime Duration { get; set; }

        public string Category { get; set; }

        public string Purpose { get; set; }
    }
}
