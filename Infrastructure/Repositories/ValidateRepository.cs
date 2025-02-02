using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ValidateRepository : IValidateRepository
    {
        private readonly ApplicationDbContext _context;

        public ValidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Validate>> GetAllValidationsAsync()
        {
            return await _context.Validate
                .Include(v => v.Exam)
                .Include(v => v.Professor)
                .ToListAsync();
        }

        public async Task AddValidationAsync(Validate validation)
        {
            validation.ValidationDate = DateTime.UtcNow; // Establecer la fecha actual
            await _context.Validate.AddAsync(validation);
            await _context.SaveChangesAsync();
        }
    }
}
