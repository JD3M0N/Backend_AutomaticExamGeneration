using Domain.Entities;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeachRepository : ITeachRepository
    {
        private readonly ApplicationDbContext _context;

        public TeachRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeachDto>> GetTeachesAsync()
        {
            return await _context.Teach
                                 .Include(t => t.Professor)
                                 .Include(t => t.Assignment)
                                 .Select(t => new TeachDto
                                 {
                                     ProfessorId = t.ProfessorId,
                                     ProfessorName = t.Professor.Name, // Asumiendo que `Name` es la propiedad del profesor
                                     AssignmentId = t.AssignmentId,
                                     AssignmentName = t.Assignment.Name // Asumiendo que `Name` es la propiedad de la asignatura
                                 })
                                 .ToListAsync();
        }

        public async Task AddTeachAsync(Teach teach)
        {
            await _context.Teach.AddAsync(teach);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeachAsync(int id)
        {
            var teach = await _context.Teach.FindAsync(id);
            if (teach != null)
            {
                _context.Teach.Remove(teach);
                await _context.SaveChangesAsync();
            }
        }
    }
}
