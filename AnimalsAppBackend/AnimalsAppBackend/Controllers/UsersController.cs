using AnimalsAppBackend.ApplicationSerices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManagementService _usersManagementService;

        public UsersController(IUsersManagementService usersManagementService)
        {
            _usersManagementService = usersManagementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _usersManagementService.GetUser(id);
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersManagementService.GetAllUsers();
            if (result.Valid)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
