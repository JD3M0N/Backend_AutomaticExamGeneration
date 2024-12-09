using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetExamsAsync();
        Task<Exam> GetExamByIdAsync(int id);
        Task AddExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(int id);
    }
}
