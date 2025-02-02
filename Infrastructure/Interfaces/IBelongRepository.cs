using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBelongRepository
    {
        Task AddBelongAsync(Belong belong);
        Task<IEnumerable<Belong>> GetAllBelongsAsync();
        Task<Belong> GetBelongByIdAsync(int id);
        Task UpdateBelongAsync(Belong belong);
        Task DeleteBelongAsync(int id);
        Task SaveChangesAsync();
        Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId);
    }
}
