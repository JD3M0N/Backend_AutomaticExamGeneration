using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace Application.Interfaces
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetExamsAsync();
        Task<Exam> GetExamByIdAsync(int id);
        Task AddExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(int id);
        Task AddQuestionToExamAsync(int examId, int questionId);
        Task<IEnumerable<Question>> GetQuestionsForExamAsync(int examId);
        Task UpdateExamStateAsync(int examId, string state);
        Task<Exam> GenerateExamAsync(ExamGenerationRequestDto request);
    }

}
