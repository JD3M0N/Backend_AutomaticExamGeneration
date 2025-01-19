using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task AddQuestionAsync(Question question)
        {
            await _questionRepository.AddQuestionAsync(question);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllQuestionsAsync();
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionRepository.DeleteQuestionAsync(id);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _questionRepository.UpdateQuestionAsync(question);
        }
        public async Task AddEnterAsync(int professorId, int questionId)
        {
            var enter = new Enter
            {
                ProfessorId = professorId,
                QuestionId = questionId
            };
            await _questionRepository.AddEnterAsync(enter);
        }
    }
}
