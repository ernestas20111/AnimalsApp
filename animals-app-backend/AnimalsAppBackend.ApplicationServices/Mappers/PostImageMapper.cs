using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.Domain;

namespace AnimalsAppBackend.ApplicationServices.Mappers
{
    public static class PostImageMapper
    {
        public static PostImageDto MapPostImageDtoFromPostImage(PostImage postImage)
        {
            return new PostImageDto
            {
                Id = postImage.Id,
                PostId = postImage.PostId,
                ImageUrl = postImage.ImageUrl
            };
        }

        public static PostImage MapPostImageFromPostImageDto(PostImageDto postImageDto)
        {
            return new PostImage
            {
                Id = postImageDto.Id,
                PostId = postImageDto.PostId,
                ImageUrl = postImageDto.ImageUrl
            };
        }

        public static void MapPostImageFromPostImageDto(PostImage postImage, PostImageDto postImageDto)
        {
            postImage.PostId = postImageDto.PostId;
            postImage.ImageUrl = postImage.ImageUrl;
        }
    }
}
