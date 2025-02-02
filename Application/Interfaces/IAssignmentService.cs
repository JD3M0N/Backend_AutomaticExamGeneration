using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAssignmentsAsync();
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int id);
        Task<int?> GetAssignmentIdByNameAsync(string name);
        Task<IEnumerable<Exam>> GetExamsByAssignmentIdAsync(int assignmentId);
        Task<IEnumerable<Topic>> GetTopicsByAssignmentIdAsync(int assignmentId);
    }
}
