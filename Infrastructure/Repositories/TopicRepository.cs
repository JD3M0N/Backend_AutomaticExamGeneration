using Domain.Entities;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTopicAsync(Topic topic)
        {
            await _context.Topic.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync()
        {
            return await _context.Topic
                .Include(t => t.Assignment)
                .Select(t => new TopicDto
                {
                    Name = t.Name,
                    AssignmentName = t.Assignment.Name
                })
                .ToListAsync();
        }


        public async Task DeleteTopicAsync(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            if (topic != null)
            {
                _context.Topic.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            _context.Topic.Update(topic);
            await _context.SaveChangesAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _context.Topic
                .Include(t => t.Assignment) // Incluir la relación con Assignment
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Topic> GetTopicByNameAsync(string name) 
        {
            return await _context.Topic.FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}
