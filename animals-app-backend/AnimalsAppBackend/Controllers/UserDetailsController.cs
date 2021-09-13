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
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsManagementService _userDetailsManagementService;

        public UserDetailsController(IUserDetailsManagementService userDetailsManagementService)
        {
            _userDetailsManagementService = userDetailsManagementService;
        }

        [HttpGet("{userId}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _userDetailsManagementService.GetUserDetails(userId);
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Add(UserDetailsDto userDetailsDto)
        {
            var result = await _userDetailsManagementService.AddUserDetails(userDetailsDto);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDetailsDto userDetailsDto)
        {
            userDetailsDto.Id = id;
            var result = await _userDetailsManagementService.UpdateUserDetails(userDetailsDto);
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
            var result = await _userDetailsManagementService.RemoveUserDetails(id);
            if (result.Valid)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
