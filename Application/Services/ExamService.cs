using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;

        public ExamService(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
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

        public async Task UpdateExamStateAsync(int examId, string state)
        {
            await _examRepository.UpdateExamStateAsync(examId, state);
        }

        public async Task<Exam> GenerateExamAsync(ExamGenerationRequestDto request)
        {
            var totalDifficulty = request.Questions.Sum(q => q.Difficulty);
            var topicLimit = request.Questions.Select(q => q.TopicId).Distinct().Count();

            var exam = new Exam
            {
                AssignmentId = request.AssignmentId,
                ProfessorId = request.ProfessorId,
                Date = DateTime.UtcNow,
                TotalQuestions = request.Questions.Count,
                Difficulty = totalDifficulty,
                TopicLimit = topicLimit,
                State = "null" // Estado inicial como null hasta que sea verificado
            };

            await _examRepository.AddExamAsync(exam);

            foreach (var selection in request.Questions)
            {
                var question = await _questionRepository.GetQuestionByTopicAndDifficultyAsync(selection.TopicId, selection.Difficulty);
                if (question != null)
                {
                    await _examRepository.AddQuestionToExamAsync(exam.Id, question.Id);
                }
            }

            return exam;
        }
    }
}
