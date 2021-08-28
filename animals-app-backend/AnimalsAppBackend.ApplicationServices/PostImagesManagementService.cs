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
    public class PostImagesManagementService : IPostImagesManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostImagesManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PostImageDto>>> GetAllPostImages()
        {
            var postImages = await _unitOfWork.PostImages.GetAll().ToListAsync();
            if (postImages is null || postImages.Count == 0)
            {
                return Result<List<PostImageDto>>.CreateErrorResult($"No post images were found.");
            }

            var postImagesDto = postImages.Select(postImage => PostImageMapper.MapPostImageDtoFromPostImage(postImage)).ToList();

            return Result<List<PostImageDto>>.Create(postImagesDto);
        }

        public async Task<Result<List<PostImageDto>>> GetPostImagesByPostId(Guid id)
        {
            var postImages = await _unitOfWork.PostImages.Find(post => post.PostId == id).ToListAsync();
            if (postImages is null)
            {
                return Result<List<PostImageDto>>.CreateErrorResult($"Post images with id {id} was not found.");
            }

            var postImagesDto = postImages.Select(postImage => PostImageMapper.MapPostImageDtoFromPostImage(postImage)).ToList();

            return Result<List<PostImageDto>>.Create(postImagesDto);
        }

        public async Task<Result<string>> RemovePostImage(Guid id)
        {
            var postImage = await _unitOfWork.PostImages.GetById(id);
            if (postImage is null)
            {
                return Result<string>.CreateErrorResult($"Post image with id {id} was not found.");
            }

            try
            {
                _unitOfWork.PostImages.Remove(postImage);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(id.ToString());
        }

        public async Task<Result<PostImageDto>> AddPostImage(PostImageDto postImageDto)
        {
            PostImage newPostImage;
            try
            {
                newPostImage = _unitOfWork.PostImages.Add(PostImageMapper.MapPostImageFromPostImageDto(postImageDto));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<PostImageDto>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<PostImageDto>.Create(PostImageMapper.MapPostImageDtoFromPostImage(newPostImage));
        }

        public async Task<Result<string>> UpdatePostImage(PostImageDto postImageDto)
        {
            var postImage = await _unitOfWork.PostImages.GetById(postImageDto.Id);
            if (postImage is null)
            {
                return Result<string>.CreateErrorResult($"Post image with id {postImageDto.Id} was not found.");
            }

            try
            {
                PostImageMapper.MapPostImageFromPostImageDto(postImage, postImageDto);
                _unitOfWork.PostImages.Update(postImage);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Result<string>.CreateErrorResult("Oops! Something went wrong, please refresh the page and try again.");
            }

            return Result<string>.Create(postImageDto.Id.ToString());
        }
    }
}
