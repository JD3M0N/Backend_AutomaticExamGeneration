using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStatsRepository
    {
        Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId);
        Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentNameAsync(string assignmentName);
    }
}
