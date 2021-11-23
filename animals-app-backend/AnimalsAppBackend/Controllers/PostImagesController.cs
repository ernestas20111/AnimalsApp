using AnimalsAppBackend.ApplicationServices;
using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationUtilities.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.Controllers
{
    [ApiController]
    [ValidateModel]
    [Route("[controller]", Order = 1)]
    [Route("api/v{version:apiVersion}/[controller]", Order = 2)]
    [ApiVersion("1")]
    public class PostImagesController : ControllerBase
    {
        private readonly IPostImagesManagementService _postImagesManagementService;

        public PostImagesController(IPostImagesManagementService postImagesManagementService)
        {
            _postImagesManagementService = postImagesManagementService;
        }

        [HttpGet("{postId}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(Guid postId)
        {
            var result = await _postImagesManagementService.GetPostImagesByPostId(postId);
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postImagesManagementService.GetAllPostImages();
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Add(PostImageDto postImageDto)
        {
            var result = await _postImagesManagementService.AddPostImage(postImageDto);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PostImageDto postImageDto)
        {
            postImageDto.Id = id;
            var result = await _postImagesManagementService.UpdatePostImage(postImageDto);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _postImagesManagementService.RemovePostImage(id);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
