using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOwnRepository
    {
        Task AddOwnAsync(Own own);
        Task<IEnumerable<Own>> GetAllOwnsAsync();
        Task<Own> GetOwnByIdAsync(int id);
        Task UpdateOwnAsync(Own own);
        Task DeleteOwnAsync(int id);
    }
}
