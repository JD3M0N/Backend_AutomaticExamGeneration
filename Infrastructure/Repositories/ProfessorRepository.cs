using Application.Interfaces;
using Domain.Entities;
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

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professors.ToListAsync();
        }
    }
}
