using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
{
    public interface IPostImagesManagementService
    {
        Task<Result<List<PostImageDto>>> GetPostImagesByPostId(Guid id);

        Task<Result<List<PostImageDto>>> GetAllPostImages();

        Task<Result<PostImageDto>> AddPostImage(PostImageDto postImageDto);

        Task<Result<string>> UpdatePostImage(PostImageDto postImageDto);

        Task<Result<string>> RemovePostImage(Guid id);
    }
}
