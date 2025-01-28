using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RequestRegradeRepository : IRequestRegradeRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRegradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestRegrade>> GetAllRequestRegradesAsync()
        {
            return await _context.RequestRegrade.ToListAsync();
        }

        public async Task<RequestRegrade> GetRequestRegradeByIdAsync(int id)
        {
            return await _context.RequestRegrade.FindAsync(id);
        }

        public async Task AddRequestRegradeAsync(RequestRegrade requestRegrade)
        {
            await _context.RequestRegrade.AddAsync(requestRegrade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestRegradeAsync(RequestRegrade requestRegrade)
        {
            _context.RequestRegrade.Update(requestRegrade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestRegradeAsync(int id)
        {
            var requestRegrade = await _context.RequestRegrade.FindAsync(id);
            if (requestRegrade != null)
            {
                _context.RequestRegrade.Remove(requestRegrade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
