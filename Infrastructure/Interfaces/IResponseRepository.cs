using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetResponsesAsync();
        Task<Response> GetResponseByIdAsync(int studentId, int examId);
        Task AddResponseAsync(Response response);
        Task UpdateResponseAsync(Response response);
        Task DeleteResponseAsync(int studentId, int examId);
    }
}

