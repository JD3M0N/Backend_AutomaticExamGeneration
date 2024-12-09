using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
