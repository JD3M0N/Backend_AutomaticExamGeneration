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
            // Check if the topic belongs to an assignment that the professor teaches
            return await _context.Topic
                .Where(t => t.Id == topicId)
                .AnyAsync(t => _context.Assignment
                    .Where(a => a.Id == t.AssignmentId)
                    .Any(a => a.ProfessorId == professorId ||
                              _context.Teach.Any(te => te.AssignmentId == a.Id && te.ProfessorId == professorId)));
        }

    }
}
