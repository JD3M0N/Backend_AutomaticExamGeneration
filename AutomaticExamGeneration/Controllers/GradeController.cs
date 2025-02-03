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

        [HttpGet("student/{studentId}/exam/{examId}")]
        public async Task<IActionResult> GetStudentExamGrade(int studentId, int examId)
        {
            var result = await _gradeService.GetStudentExamGradeAsync(studentId, examId);

            if (result == "El estudiante no ha realizado el examen" || result == "El examen aún no ha sido calificado")
            {
                // Write to the console the message
                System.Console.WriteLine(result);

                return NotFound(new { message = result });
            }

            // Write to the console the student ID, the exam ID and the grade
            System.Console.WriteLine($"Student ID: {studentId}, Exam ID: {examId}, Grade: {result}");

            return Ok(new { StudentId = studentId, ExamId = examId, Grade = result });
        }

        [HttpGet("student/{studentId}/graded-exams")]
        public async Task<IActionResult> GetStudentGradedExams(int studentId)
        {
            var result = await _gradeService.GetStudentGradedExamsAsync(studentId);

            if (result.Count == 0)
            {
                // Write to the console the message
                System.Console.WriteLine("El estudiante no tiene exámenes calificados");

                return NotFound(new { message = "El estudiante no tiene exámenes calificados" });
            }

            // Write to the console the student ID and the number of graded exams
            System.Console.WriteLine($"Student ID: {studentId}, Graded exams: {result.Count}");

            return Ok(result);
        }

        [HttpGet("student/{studentId}/assignment/{assignmentId}/grades")]
        public async Task<IActionResult> GetStudentGradesByAssignment(int studentId, int assignmentId)
        {
            var result = await _gradeService.GetStudentGradesByAssignmentAsync(studentId, assignmentId);

            if (result.Count == 0)
            {
                // Write to the console the message
                System.Console.WriteLine("El estudiante no tiene exámenes calificados en esta asignatura");

                return NotFound(new { message = "El estudiante no tiene exámenes calificados en esta asignatura" });
            }

            // Write to the console the student ID, the assignment ID and the number of grades
            System.Console.WriteLine($"Student ID: {studentId}, Assignment ID: {assignmentId}, Grades: {result.Count}");

            return Ok(result);
        }

    }
}
