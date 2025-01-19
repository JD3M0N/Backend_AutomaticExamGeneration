using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync()
        {
            return await _context.Admin.ToListAsync();
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await _context.Admin.FindAsync(id);
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admin.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin != null)
            {
                _context.Admin.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            return await _context.Admin.FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
