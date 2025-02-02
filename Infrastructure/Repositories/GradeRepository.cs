using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetAllGradesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task AddGradeAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGradeAsync(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGradeAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetStudentExamGradeAsync(int studentId, int examId)
        {
            var responses = await _context.Response
                .Where(r => r.StudentId == studentId && r.ExamId == examId)
                .ToListAsync();

            if (!responses.Any())
                return "El estudiante no ha realizado el examen"; // No hay respuestas

            var grades = await _context.Grades
                .Where(g => g.StudentId == studentId && g.ExamId == examId)
                .ToListAsync();

            if (!grades.Any())
                return "El examen aún no ha sido calificado"; // No hay calificaciones en la tabla Grade

            var totalScore = grades.Sum(g => g.GradeValue);
            var totalQuestions = await _context.Belong.CountAsync(b => b.ExamId == examId);

            if (totalQuestions == 0)
                return "Nota no disponible"; // Evita división por cero

            double finalGrade = (double)totalScore / totalQuestions;
            return finalGrade.ToString("F2"); // Retorna el promedio con 2 decimales
        }

        public async Task<List<object>> GetStudentGradedExamsAsync(int studentId)
        {
            var examIds = await _context.Grades
                .Where(g => g.StudentId == studentId)
                .Select(g => g.ExamId)
                .Distinct()
                .ToListAsync();

            if (!examIds.Any())
                return new List<object> { new { message = "El estudiante no tiene exámenes calificados" } };

            var gradedExams = new List<object>();

            foreach (var examId in examIds)
            {
                var grades = await _context.Grades
                    .Where(g => g.StudentId == studentId && g.ExamId == examId)
                    .ToListAsync();

                var totalScore = grades.Sum(g => g.GradeValue);
                var totalQuestions = await _context.Belong.CountAsync(b => b.ExamId == examId);

                if (totalQuestions == 0)
                    continue; // Evita incluir exámenes sin preguntas

                double finalGrade = (double)totalScore / totalQuestions;
                gradedExams.Add(new
                {
                    ExamId = examId,
                    Grade = finalGrade.ToString("F2") // Formato con dos decimales
                });
            }

            return gradedExams;
        }

    }
}
