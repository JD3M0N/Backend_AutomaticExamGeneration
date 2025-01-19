using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnrollRepository : IEnrollRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEnrollAsync(Enroll enroll)
        {
            await _context.Enroll.AddAsync(enroll);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByStudentIdAsync(int studentId)
        {
            return await _context.Enroll
                .Where(e => e.StudentId == studentId)
                .Select(e => e.Assignment)
                .ToListAsync();
        }

        public async Task DeleteEnrollAsync(int studentId, int assignmentId)
        {
            var enroll = await _context.Enroll
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.AssignmentId == assignmentId);
            if (enroll != null)
            {
                _context.Enroll.Remove(enroll);
                await _context.SaveChangesAsync();
            }
        }
    }
}
