using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            var existingStudent = await _context.Student.AsNoTracking().FirstOrDefaultAsync(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                await _context.Student.AddAsync(student);
            }
            else
            {
                _context.Entry(student).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }




        public async Task ClearStudentsAsync()
        {
            _context.Student.RemoveRange(_context.Student);
            await _context.SaveChangesAsync();
        }
    }
}
