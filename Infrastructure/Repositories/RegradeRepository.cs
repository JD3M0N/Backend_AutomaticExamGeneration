using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RegradeRepository : IRegradeRepository
    {
        private readonly ApplicationDbContext _context;

        public RegradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Regrade>> GetAllRegradesAsync()
        {
            return await _context.Regrades.ToListAsync();
        }

        public async Task<Regrade> GetRegradeByIdAsync(int id)
        {
            return await _context.Regrades.FindAsync(id);
        }

        public async Task AddRegradeAsync(Regrade regrade)
        {
            await _context.Regrades.AddAsync(regrade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRegradeAsync(Regrade regrade)
        {
            _context.Regrades.Update(regrade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRegradeAsync(int id)
        {
            var regrade = await _context.Regrades.FindAsync(id);
            if (regrade != null)
            {
                _context.Regrades.Remove(regrade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
