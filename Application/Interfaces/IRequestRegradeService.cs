using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IRequestRegradeService
    {
        Task<IEnumerable<RequestRegradeDto>> GetAllRequestRegradesAsync();
        Task<RequestRegradeDto> GetRequestRegradeByIdAsync(int id);
        Task AddRequestRegradeAsync(RequestRegradeDto requestRegradeDto);
        Task UpdateRequestRegradeAsync(int id, RequestRegradeDto requestRegradeDto);
        Task DeleteRequestRegradeAsync(int id);
    }
}
