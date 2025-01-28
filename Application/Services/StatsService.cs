using Application.Interfaces;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace Application.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId)
        {
            return await _statsRepository.GetExamsByAssignmentAsync(assignmentId);
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentNameAsync(string assignmentName)
        {
            return await _statsRepository.GetExamsByAssignmentNameAsync(assignmentName);
        }
    }

}
