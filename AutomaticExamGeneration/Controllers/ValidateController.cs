using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService _validateService;

        public ValidateController(IValidateService validateService)
        {
            _validateService = validateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidateDto>>> GetAllValidations()
        {
            var validations = await _validateService.GetAllValidationsAsync();

            // Write in console that we are getting all validations
            System.Console.WriteLine("Getting all validations");

            return Ok(validations);
        }

        [HttpPost]
        public async Task<IActionResult> AddValidation([FromBody] ValidateDto validateDto)
        {
            await _validateService.AddValidationAsync(validateDto);

            // Write in console that a validation was added successfully with that professor and exam
            System.Console.WriteLine($"Validation added successfully with Professor ID {validateDto.ProfessorId} and Exam ID {validateDto.ExamId}");

            return Ok(new { message = "Validation added successfully" });
        }
    }
}
