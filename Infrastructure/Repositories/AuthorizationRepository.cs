using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanAddQuestionAsync(int professorId, int topicId)
        {
            return await _context.Own
                .Where(o => o.TopicId == topicId)
                .AnyAsync(o => _context.Assignment
                    .Where(a => a.Id == o.AssignmentId)
                    .Any(a => a.ProfessorId == professorId));
        }
    }
}
