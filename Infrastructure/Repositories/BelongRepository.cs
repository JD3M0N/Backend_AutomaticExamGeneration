using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BelongRepository : IBelongRepository
    {
        private readonly ApplicationDbContext _context;

        public BelongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Belong>> GetAllBelongsAsync()
        {
            return await _context.Belong
                .Include(b => b.Question)
                .Include(b => b.Exam)
                .ToListAsync();
        }

        public async Task<Belong> GetBelongByIdAsync(int id)
        {
            return await _context.Belong
                .Include(b => b.Question)
                .Include(b => b.Exam)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBelongAsync(Belong belong)
        {
            await _context.Belong.AddAsync(belong);
        }

        public async Task UpdateBelongAsync(Belong belong)
        {
            _context.Belong.Update(belong);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBelongAsync(int id)
        {
            var belong = await _context.Belong.FindAsync(id);
            if (belong != null)
            {
                _context.Belong.Remove(belong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
