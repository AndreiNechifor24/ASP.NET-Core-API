using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepositories;

namespace ParkyAPI.Controllers
{
    [Route("api/v{version:apiVersion}/Users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] User model)
        {
            var user = _userRepository.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
