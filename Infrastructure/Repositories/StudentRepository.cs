﻿using Domain.Entities;
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

            // Ensure the student ID is not set manually
            student.Id = 0;

            //var existingStudent = await _context.Student.FindAsync(student.Id);
            //if (existingStudent != null)
            //{
            //    _context.Entry(existingStudent).State = EntityState.Detached;
            //}

            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
        }


        public async Task ClearStudentsAsync()
        {
            _context.Student.RemoveRange(_context.Student);
            await _context.SaveChangesAsync();
        }
    }
}
