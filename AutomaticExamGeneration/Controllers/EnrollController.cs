using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EnrollController : ControllerBase
    {
        private readonly IEnrollService _enrollService;

        public EnrollController(IEnrollService enrollService)
        {
            _enrollService = enrollService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEnroll([FromBody] EnrollDto enrollDto)
        {
            if (enrollDto == null)
            {
                return BadRequest("Invalid data.");
            }

            await _enrollService.EnrollStudentAsync(enrollDto);

            // Write to console that an enrollment relationship has been added
            System.Console.WriteLine($"Enroll relationship added for student ID {enrollDto.S_ID} and assignment ID {enrollDto.A_ID}.");

            return Ok("Enroll relationship added successfully.");
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAssignmentsByStudentId(int studentId)
        {
            // Llamar al servicio para obtener las asignaciones del estudiante
            var assignments = await _enrollService.GetStudentAssignmentsAsync(studentId);

            if (assignments == null || !assignments.Any())
            {
                return NotFound($"No assignments found for student with ID {studentId}.");
            }

            // Write to console the assignments found for the student
            System.Console.WriteLine($"Assignments found for student ID {studentId}.");

            return Ok(assignments);
        }

        [HttpGet("assignment/{assignmentId}")]
        public async Task<IActionResult> GetStudentsByAssignmentId(int assignmentId)
        {
            // Llamar al servicio para obtener los estudiantes relacionados con la asignación
            var students = await _enrollService.GetStudentsByAssignmentIdAsync(assignmentId);

            if (students == null || !students.Any())
            {
                return NotFound($"No students found for assignment with ID {assignmentId}.");
            }

            // Write to console the students found for the assignment
            System.Console.WriteLine($"Students found for assignment ID {assignmentId}.");

            return Ok(students);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEnroll([FromQuery] int studentId, [FromQuery] int assignmentId)
        {
            // Llamar al servicio para eliminar la relación de inscripción
            await _enrollService.UnenrollStudentAsync(studentId, assignmentId);

            // Write to console that an enrollment relationship has been deleted
            System.Console.WriteLine($"Enroll relationship between student ID {studentId} and assignment ID {assignmentId} deleted.");

            return Ok($"Enrollment relationship between student ID {studentId} and assignment ID {assignmentId} deleted successfully.");
        }

    }
}