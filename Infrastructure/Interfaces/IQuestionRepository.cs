using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task DeleteQuestionAsync(int id);
        Task UpdateQuestionAsync(Question question);
        Task<Question> GetQuestionByIdAsync(int id);
        Task AddEnterAsync(Enter enter);
    }
}
