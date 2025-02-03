using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> GetProfessorsAsync()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _context.Professor.FindAsync(id);
        }

        public async Task AddProfessorAsync(Professor professor)
        {
            await _context.Professor.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            _context.Professor.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Professor> GetProfessorByEmailAsync(string email)
        {
            return await _context.Professor.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<bool> IsHeadOfAssignmentAsync(int professorId)
        {
            return await _context.Assignment.AnyAsync(a => a.ProfessorId == professorId);
        }

        public async Task<IEnumerable<Exam>> GetUnvalidatedExamsByProfessorIdAsync(int professorId)
        {
            return await _context.Exam
                .Where(e => e.Assignment.ProfessorId == professorId &&
                            !_context.Validate.Any(v => v.ExamId == e.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetReviewableExamsAsync(int professorId)
        {
            return await _context.Exam
                .Where(e => _context.Response.Any(r => r.ExamId == e.Id) &&
                            !_context.Grades.Any(g => g.ExamId == e.Id) &&
                            _context.Teach.Any(t => t.ProfessorId == professorId && t.AssignmentId == e.AssignmentId))
                .ToListAsync();
        }
    }
}
