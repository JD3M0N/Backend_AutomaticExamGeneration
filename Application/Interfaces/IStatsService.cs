using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStatsService
    {
        Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId);
    }
}
