using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
        {
            return await _context.Assignment.ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _context.Assignment.FindAsync(id);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _context.Assignment.AddAsync(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignment.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignment.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Assignment> GetAssignmentByNameAsync(string name)
        {
            return await _context.Assignment.FirstOrDefaultAsync(a => a.Name == name);
        }
        public async Task<IEnumerable<Exam>> GetExamsByAssignmentIdAsync(int assignmentId)
        {
            return await _context.Exam
                .Where(e => e.AssignmentId == assignmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByAssignmentIdAsync(int assignmentId)
        {
            return await _context.Topic
                .Where(t => t.AssignmentId == assignmentId)
                .ToListAsync();
        }

    }
}
