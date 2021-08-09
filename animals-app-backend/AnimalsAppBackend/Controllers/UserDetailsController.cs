using AnimalsAppBackend.Abstractions;
using AnimalsAppBackend.ApplicationServices;
using AnimalsAppBackend.ApplicationServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.Controllers
{
    [ApiController]
    [ValidateModel]
    [Route("[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsManagementService _userDetailsManagementService;

        public UserDetailsController(IUserDetailsManagementService userDetailsManagementService)
        {
            _userDetailsManagementService = userDetailsManagementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)// susieti su kita lentele
        {
            var result = await _userDetailsManagementService.GetUserDetails(id);
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
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
