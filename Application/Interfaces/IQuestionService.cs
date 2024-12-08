using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(int difficulty, string type, string questionText, int topicId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task DeleteQuestionAsync(int id);
        Task UpdateQuestionAsync(int id, int difficulty, string type, string questionText);
    }
}
