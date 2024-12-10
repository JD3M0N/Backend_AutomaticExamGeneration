using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IResponseService
    {
        Task<IEnumerable<Response>> GetResponseAsync();
        Task AddResponseAsync(Response response);
        Task UpdateResponseAsync(Response response);
        Task DeleteResponseAsync(int id);
    }
}
