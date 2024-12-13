using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(Question question);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task DeleteQuestionAsync(int id);
        Task UpdateQuestionAsync(Question question);
    }
}
