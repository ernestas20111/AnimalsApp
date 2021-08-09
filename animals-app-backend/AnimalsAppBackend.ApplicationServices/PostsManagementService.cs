using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationServices.Mappers;
using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsAppBackend.ApplicationServices
{
    public class PostsManagementService : IPostsManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PostDto>>> GetAllPosts()
        {
            var posts = await _unitOfWork.Posts.GetAll().ToListAsync();
            if (posts is null || posts.Count == 0)
            {
                return Result<List<PostDto>>.CreateErrorResult($"No posts were found.");
            }

            return Result<List<PostDto>>.Create(posts.Select(post => PostMapper.MapPostDtoFromPost(post)).ToList());
        }

        public async Task<Result<List<PostDto>>> GetPostsByUserId(Guid id)
        {
            var posts = await _unitOfWork.Posts.Find(post => post.UserId == id).ToListAsync();
            if (posts is null)
            {
                return Result<List<PostDto>>.CreateErrorResult($"Posts with id {id} was not found.");
            }

            return Result<List<PostDto>>.Create(posts.Select(post => PostMapper.MapPostDtoFromPost(post)).ToList());
        }

        public async Task<Result<string>> RemovePost(Guid id)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            if (post is null)
            {
                return Result<string>.CreateErrorResult($"Post with id {id} was not found.");
            }

            try
            {
                _unitOfWork.Posts.Remove(post);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(id.ToString());
        }

        public async Task<Result<PostDto>> AddPost(PostDto postDto)
        {
            Post newPost;
            try
            {
                newPost = _unitOfWork.Posts.Add(PostMapper.MapPostFromPostDto(postDto));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<PostDto>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<PostDto>.Create(PostMapper.MapPostDtoFromPost(newPost));
        }

        public async Task<Result<string>> UpdatePost(PostDto postDto)
        {
            var post = await _unitOfWork.Posts.GetById(postDto.Id);
            if (post is null)
            {
                return Result<string>.CreateErrorResult($"Post with id {postDto.Id} was not found.");
            }

            try
            {
                PostMapper.MapPostFromPostDto(post, postDto);
                _unitOfWork.Posts.Update(post);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(postDto.Id.ToString());
        }
    }
}
