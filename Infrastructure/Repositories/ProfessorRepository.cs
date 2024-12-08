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

        //public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        //{
        //    return await _context.Professor.ToListAsync();
        //}

        public async Task AddProfessorAsync(Professor professor)
        {
            await _context.Professor.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteProfessorAsync(Professor professor)
        //{
        //    _context.Professor.Remove(professor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task ClearProfessorsAsync()
        //{
        //    _context.Professor.RemoveRange(_context.Professor);
        //    await _context.SaveChangesAsync();
        //}
    }
}
