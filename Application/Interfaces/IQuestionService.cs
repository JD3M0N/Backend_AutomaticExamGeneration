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
        Task AddEnterAsync(int professorId, int questionId);
        Task<IEnumerable<Question>> GetQuestionsByProfessorIdAsync(int professorId);
        Task<Question> GetQuestionByIdAsync(int id);
    }
}
