using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    public AdminRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
    {
        return await _context.Admin.ToListAsync();
    }

    public async Task ClearAdminsAsync()
    {
        _context.Admin.RemoveRange(_context.Admin);
        await _context.SaveChangesAsync();
    }
}
