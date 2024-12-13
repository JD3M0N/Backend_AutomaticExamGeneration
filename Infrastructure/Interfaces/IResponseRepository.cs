using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetResponseAsync();
        Task<Response> GetResponseByIdAsync(int id);
        Task AddResponseAsync(Response response);
        Task UpdateResponseAsync(Response response);
        Task DeleteResponseAsync(int id);
    }
}
