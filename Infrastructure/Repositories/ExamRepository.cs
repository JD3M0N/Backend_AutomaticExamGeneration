using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetExamsAsync()
        {
            return await _context.Exam.ToListAsync();
        }

        public async Task<Exam> GetExamByIdAsync(int id)
        {
            return await _context.Exam.FindAsync(id);
        }

        public async Task AddExamAsync(Exam exam)
        {
            await _context.Exam.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            _context.Exam.Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExamAsync(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            if (exam != null)
            {
                _context.Exam.Remove(exam);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddQuestionToExamAsync(int examId, int questionId)
        {
            var belong = new Belong
            {
                ExamId = examId,
                QuestionId = questionId
            };
            await _context.Belong.AddAsync(belong);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionsForExamAsync(int examId)
        {
            return await _context.Belong
                .Where(b => b.ExamId == examId)
                .Select(b => b.Question)
                .ToListAsync();
        }

        public async Task UpdateExamStateAsync(int examId, string state)
        {
            var exam = await _context.Exam.FindAsync(examId);
            if (exam != null)
            {
                exam.State = state;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Exam>> GetUnattemptedExamsAsync(int studentId, int assignmentId)
        {
            return await _context.Exam
                .Where(e => e.AssignmentId == assignmentId && e.State == "validated")
                .Where(e => !_context.Response.Any(r => r.StudentId == studentId && r.ExamId == e.Id))
                .ToListAsync();
        }
    }
}
