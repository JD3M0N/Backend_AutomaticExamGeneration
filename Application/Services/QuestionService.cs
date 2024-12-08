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

        public async Task AddQuestionAsync(int difficulty, string type, string questionText, int topicId)
        {
            var question = new Question
            {
                Difficulty = difficulty,
                Type = type,
                QuestionText = questionText,
                TopicId = topicId
            };

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

        public async Task UpdateQuestionAsync(int id, int difficulty, string type, string questionText)
        {
            var question = await _questionRepository.GetQuestionByIdAsync(id);
            if (question != null)
            {
                question.Difficulty = difficulty;
                question.Type = type;
                question.QuestionText = questionText;
                await _questionRepository.UpdateQuestionAsync(question);
            }
        }
    }
}
