using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserValidationService _userValidationService;

        public AdminController(IAdminService adminService, IUserValidationService userValidationService)
        {
            _adminService = adminService;
            _userValidationService = userValidationService;
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto adminDto)
        {
            if (await _userValidationService.EmailExistsAsync(adminDto.Email))
            {
                Console.WriteLine("El correo ya está registrado.");
                return BadRequest(new { message = "El correo ya está registrado." });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);

            var admin = new Admin
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = hashedPassword // Guardar la contraseña hasheada
            };

            await _adminService.AddAdminAsync(admin);
            Console.WriteLine($"admin '{admin.Name}' added correctly.");
            return Ok(admin);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAdminsAsync();
            return Ok(admins);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] AdminDto adminDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);

            var admin = new Admin
            {
                Id = id,
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = hashedPassword
            };

            await _adminService.UpdateAdminAsync(admin);
            Console.WriteLine($"admin '{admin.Name}' modified correctly.");
            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return Ok();
        }
    }
}
