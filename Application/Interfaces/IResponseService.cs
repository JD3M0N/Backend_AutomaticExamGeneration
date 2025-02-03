using Application.Dtos;
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
        Task<IEnumerable<ResponseDto>> GetAllResponsesAsync();
        Task<ResponseDto> GetResponseByIdAsync(int id);
        Task AddResponseAsync(ResponseDto responseDto);
        Task UpdateResponseAsync(int id, ResponseDto responseDto);
        Task DeleteResponseAsync(int id);
        Task<IEnumerable<ResponseDto>> GetResponsesByExamAndStudentAsync(int examId, int studentId); // Nuevo método
    }
}
