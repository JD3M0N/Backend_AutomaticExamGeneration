using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOwnService
    {
        Task AddOwnAsync(int assignmentId, int topicId);
        Task<IEnumerable<Own>> GetAllOwnsAsync();
        Task<Own> GetOwnByIdAsync(int id);
        Task UpdateOwnAsync(int id, int assignmentId, int topicId);
        Task DeleteOwnAsync(int id);
    }
}
