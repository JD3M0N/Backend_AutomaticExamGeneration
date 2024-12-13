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

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto adminDto)
        {
            
            var admin = new Admin
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = adminDto.Password
            };

            await _adminService.AddAdminAsync(admin);
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
            var admin = new Admin
            {
                Id = id,
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = adminDto.Password
            };

            await _adminService.UpdateAdminAsync(admin);
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
