using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest addUserRequest)
        {
            if (addUserRequest == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _userService.AddUserAsync(
                addUserRequest.Name,
                addUserRequest.LastName,
                addUserRequest.Email,
                addUserRequest.Rol,
                addUserRequest.Password
            );

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }

    public class AddUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
    }
}
