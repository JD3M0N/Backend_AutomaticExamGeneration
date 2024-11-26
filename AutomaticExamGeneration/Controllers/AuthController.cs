using Application.Interfaces;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var isValidUser = await _authService.ValidateUserAsync(loginRequest.Email, loginRequest.Password);
            if (!isValidUser)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
            return Ok(new { message = "User is valid" });
        }

        [HttpGet("users")] // Add this endpoint
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _authService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
