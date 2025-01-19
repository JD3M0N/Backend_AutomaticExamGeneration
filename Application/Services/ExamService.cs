using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<Exam>> GetExamsAsync()
        {
            return await _examRepository.GetExamsAsync();
        }

        public async Task<Exam> GetExamByIdAsync(int id)
        {
            return await _examRepository.GetExamByIdAsync(id);
        }

        public async Task AddExamAsync(Exam exam)
        {
            await _examRepository.AddExamAsync(exam);
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            await _examRepository.UpdateExamAsync(exam);
        }

        public async Task DeleteExamAsync(int id)
        {
            await _examRepository.DeleteExamAsync(id);
        }

        public async Task AddQuestionToExamAsync(int examId, int questionId)
        {
            await _examRepository.AddQuestionToExamAsync(examId, questionId);
        }

        public async Task<IEnumerable<Question>> GetQuestionsForExamAsync(int examId)
        {
            return await _examRepository.GetQuestionsForExamAsync(examId);
        }
    }
}
