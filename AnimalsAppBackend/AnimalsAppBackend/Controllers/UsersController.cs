﻿using AnimalsAppBackend.ApplicationSerices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnimalsAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersManagementService _usersManagementService;

        public UsersController(UsersManagementService usersManagementService)
        {
            _usersManagementService = usersManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> gets()
        {
            return Ok("nice");
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
    }
}