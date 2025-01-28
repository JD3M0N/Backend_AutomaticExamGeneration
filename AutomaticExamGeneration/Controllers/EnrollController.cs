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

            return Ok(students);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEnroll([FromQuery] int studentId, [FromQuery] int assignmentId)
        {
            // Llamar al servicio para eliminar la relación de inscripción
            await _enrollService.UnenrollStudentAsync(studentId, assignmentId);

            return Ok($"Enrollment relationship between student ID {studentId} and assignment ID {assignmentId} deleted successfully.");
        }

    }
}
