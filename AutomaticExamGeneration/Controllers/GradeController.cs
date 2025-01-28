using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetAllGrades()
        {
            var grades = await _gradeService.GetAllGradesAsync();

            // Write in console that grades were getted
            System.Console.WriteLine("Grades getted correctly.");

            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetGradeById(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null)
                return NotFound();

            // Write in console that grade was getted
            System.Console.WriteLine($"Grade with ID {id} getted correctly.");

            return Ok(grade);
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade([FromBody] GradeDto gradeDto)
        {
            await _gradeService.AddGradeAsync(gradeDto);

            // Write in console that grade was added with the student ID, the profesor and the grade
            System.Console.WriteLine($"Grade added with Student ID {gradeDto.StudentId}, Professor {gradeDto.ProfessorId} and Grade {gradeDto.GradeValue}");
            
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] GradeDto gradeDto)
        {
            await _gradeService.UpdateGradeAsync(id, gradeDto);

            // Write in console that grade was updated with the student ID, the profesor and the grade
            System.Console.WriteLine($"Grade updated with Student ID {gradeDto.StudentId}, Professor {gradeDto.ProfessorId} and Grade {gradeDto.GradeValue}");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            await _gradeService.DeleteGradeAsync(id);

            // Write in console that grade was deleted
            System.Console.WriteLine($"Grade with ID {id} deleted correctly.");

            return Ok();
        }
    }
}
