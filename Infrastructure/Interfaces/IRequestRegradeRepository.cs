using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRequestRegradeRepository
    {
        Task<IEnumerable<RequestRegrade>> GetAllRequestRegradesAsync();
        Task<RequestRegrade> GetRequestRegradeByIdAsync(int id);
        Task AddRequestRegradeAsync(RequestRegrade requestRegrade);
        Task UpdateRequestRegradeAsync(RequestRegrade requestRegrade);
        Task DeleteRequestRegradeAsync(int id);
    }
}
