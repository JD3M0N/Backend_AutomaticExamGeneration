using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBelongService
    {
        Task<IEnumerable<BelongSimpleDto>> GetAllBelongsAsync();
        Task<BelongSimpleDto> GetBelongByIdAsync(int id);
        Task AddBelongAsync(BelongDto belongDto);
        Task UpdateBelongAsync(Belong belong);
        Task DeleteBelongAsync(int id);
    }
}
