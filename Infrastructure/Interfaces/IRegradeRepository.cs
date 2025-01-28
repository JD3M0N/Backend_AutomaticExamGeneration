using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRegradeRepository
    {
        Task<IEnumerable<Regrade>> GetAllRegradesAsync();
        Task<Regrade> GetRegradeByIdAsync(int id);
        Task AddRegradeAsync(Regrade regrade);
        Task UpdateRegradeAsync(Regrade regrade);
        Task DeleteRegradeAsync(int id);
    }
}
