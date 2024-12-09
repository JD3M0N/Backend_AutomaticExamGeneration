using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamsAsync();
        Task<Exam> GetExamByIdAsync(int id);
        Task AddExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(int id);
    }
}
