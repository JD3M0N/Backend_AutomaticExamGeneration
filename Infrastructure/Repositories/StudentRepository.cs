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
                return await _context.Students.ToListAsync();
            }
        }
    }
    