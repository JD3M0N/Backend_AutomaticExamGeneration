using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OwnRepository : IOwnRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOwnAsync(Own own)
        {
            await _context.Own.AddAsync(own);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Own>> GetAllOwnsAsync()
        {
            return await _context.Own.ToListAsync();
        }

        public async Task<Own> GetOwnByIdAsync(int id)
        {
            return await _context.Own.FindAsync(id);
        }

        public async Task UpdateOwnAsync(Own own)
        {
            _context.Own.Update(own);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOwnAsync(int id)
        {
            var own = await _context.Own.FindAsync(id);
            if (own != null)
            {
                _context.Own.Remove(own);
                await _context.SaveChangesAsync();
            }
        }
    }
}
