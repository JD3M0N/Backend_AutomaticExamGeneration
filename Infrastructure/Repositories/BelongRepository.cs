using Domain.Entities;
using Infrastructure.Interfaces;
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

        public async Task AddBelongAsync(Belong belong)
        {
            await _context.Belong.AddAsync(belong);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
