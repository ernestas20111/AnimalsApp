using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.Domain;

namespace AnimalsAppBackend.ApplicationServices.Mappers
{
    public static class PostMapper
    {
        public static PostDto MapPostDtoFromPost(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                UserId = post.UserId,
                Title = post.Title,
                Description = post.Description,
                Price = post.Price,
                Duration = post.Duration,
                Category = post.Category,
                Purpose = post.Purpose
            };
        }

        public static Post MapPostFromPostDto(PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                UserId = postDto.UserId,
                Title = postDto.Title,
                Description = postDto.Description,
                Price = postDto.Price,
                Duration = postDto.Duration,
                Category = postDto.Category,
                Purpose = postDto.Purpose
            };
        }

        public static void MapPostFromPostDto(Post post, PostDto postDto)
        {
            post.UserId = postDto.UserId;
            post.Title = postDto.Title;
            post.Description = postDto.Description;
            post.Price = postDto.Price;
            post.Duration = postDto.Duration;
            post.Category = postDto.Category;
            post.Purpose = postDto.Purpose;
        }
    }
}
