using AnimalsAppBackend.ApplicationServices;
using AnimalsAppBackend.ApplicationServices.Dtos;
using AnimalsAppBackend.ApplicationUtilities.Validators;
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
    public class PostsController : ControllerBase
    {
        private readonly IPostsManagementService _postsManagementService;

        public PostsController(IPostsManagementService postsManagementService)
        {
            _postsManagementService = postsManagementService;
        }

        [HttpGet("{userId}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _postsManagementService.GetPostsByUserId(userId);
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
            var result = await _postsManagementService.GetAllPosts();
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Add(PostDto postDto)
        {
            var result = await _postsManagementService.AddPost(postDto);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PostDto postDto)
        {
            postDto.Id = id;
            var result = await _postsManagementService.UpdatePost(postDto);
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
            var result = await _postsManagementService.RemovePost(id);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
