using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStatsRepository
    {
        Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId);
        Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentNameAsync(string assignmentName);
        Task<IEnumerable<QuestionUsageStatsDto>> GetMostUsedQuestionsAsync(int assignmentId);
        Task<IEnumerable<ValidatedExamDto>> GetValidatedExamsByProfessorAsync(int professorId);
        Task<IEnumerable<ExamPerformanceDto>> GetExamPerformanceAsync(int examId);
        Task<IEnumerable<UnusedQuestionDto>> GetUnusedQuestionsAsync();
        Task<IEnumerable<ExamComparisonDto>> CompareExamsAcrossAssignmentsAsync();
    }
}
