using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegradeService
    {
        Task<IEnumerable<RegradeDto>> GetAllRegradesAsync();
        Task<RegradeDto> GetRegradeByIdAsync(int id);
        Task AddRegradeAsync(RegradeDto regradeDto);
        Task UpdateRegradeAsync(int id, RegradeDto regradeDto);
        Task DeleteRegradeAsync(int id);
    }
}
