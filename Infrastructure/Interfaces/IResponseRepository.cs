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
        Task<IEnumerable<Response>> GetAllResponsesAsync();
        Task<Response> GetResponseByIdAsync(int id);
        Task AddResponseAsync(Response response);
        Task UpdateResponseAsync(Response response);
        Task DeleteResponseAsync(int id);
        Task<IEnumerable<Response>> GetResponsesByExamAndStudentAsync(int examId, int studentId); // Nuevo método
    }
}