using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
{
    public interface IPostsManagementService
    {
        Task<Result<List<PostDto>>> GetPostsByUserId(Guid id);

        Task<Result<List<PostDto>>> GetAllPosts();

        Task<Result<PostDto>> AddPost(PostDto postDto);

        Task<Result<string>> UpdatePost(PostDto postDto);

        Task<Result<string>> RemovePost(Guid id);
    }
}
