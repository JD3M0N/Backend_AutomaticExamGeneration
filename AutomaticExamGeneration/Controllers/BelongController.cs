using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class BelongController : ControllerBase
        {
            private readonly IBelongService _belongService;

            public BelongController(IBelongService belongService)
            {
                _belongService = belongService;
            }

            [HttpPost]
            public async Task<IActionResult> AddBelong([FromBody] BelongDto belongDto)
            {
                if (belongDto == null)
                {
                    return BadRequest("Invalid data.");
                }

            //Write in console what belong has been added to what exam
            System.Console.WriteLine($"Question ID {belongDto.Q_ID} added to Exam ID {belongDto.X_ID}");
            await _belongService.AddBelongAsync(belongDto);
                return Ok("Belong relationship added successfully.");
            }
        }
    }

