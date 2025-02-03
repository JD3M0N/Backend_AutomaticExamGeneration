using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly ApplicationDbContext _context;

        public ResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Response>> GetAllResponsesAsync()
        {
            return await _context.Response.ToListAsync();
        }

        public async Task<Response> GetResponseByIdAsync(int id)
        {
            return await _context.Response.FindAsync(id);
        }

        public async Task AddResponseAsync(Response response)
        {
            await _context.Response.AddAsync(response);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResponseAsync(Response response)
        {
            _context.Response.Update(response);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResponseAsync(int id)
        {
            var response = await _context.Response.FindAsync(id);
            if (response != null)
            {
                _context.Response.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Response>> GetResponsesByExamAndStudentAsync(int examId, int studentId)
        {
            return await _context.Response
                .Where(r => r.ExamId == examId && r.StudentId == studentId)
                .ToListAsync();
        }
    }
}