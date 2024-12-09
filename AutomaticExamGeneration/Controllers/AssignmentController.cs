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
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] AssignmentDto assignmentDto)
        {
            var assignment = new Assignment
            {
                Name = assignmentDto.Name,
                StudyProgram = assignmentDto.StudyProgram,
                ProfessorId = assignmentDto.ProfessorId
            };

            await _assignmentService.AddAssignmentAsync(assignment);
            return Ok(assignment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignments()
        {
            var assignments = await _assignmentService.GetAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AssignmentDto assignmentDto)
        {
            var assignment = new Assignment
            {
                Id = id,
                Name = assignmentDto.Name,
                StudyProgram = assignmentDto.StudyProgram,
                ProfessorId = assignmentDto.ProfessorId
            };

            await _assignmentService.UpdateAssignmentAsync(assignment);
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return Ok();
        }
    }
}
