using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Response>> GetResponsesAsync()
        {
            return await _context.Response.ToListAsync();
        }

        public async Task<Response> GetResponseByIdAsync(int studentId, int examId)
        {
            return await _context.Response.FindAsync(studentId, examId);
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

        public async Task DeleteResponseAsync(int studentId, int examId)
        {
            var response = await _context.Response.FindAsync(studentId, examId);
            if (response != null)
            {
                _context.Response.Remove(response);
                await _context.SaveChangesAsync();
            }
        }
    }
}
