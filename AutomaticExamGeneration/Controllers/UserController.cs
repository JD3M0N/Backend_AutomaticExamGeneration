using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Rol))
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _userService.AddUserAsync(request.Name, request.LastName, request.Email, request.Password, request.Rol);
            return Ok(user);
        }
    }

    public class AddUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } 
    }
}
