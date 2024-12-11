using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;

        public ResponseService(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<IEnumerable<Response>> GetResponsesAsync()
        {
            return await _responseRepository.GetResponsesAsync();
        }

        public async Task<Response> GetResponseByIdAsync(int studentId, int examId)
        {
            return await _responseRepository.GetResponseByIdAsync(studentId, examId);
        }

        public async Task AddResponseAsync(Response response)
        {
            await _responseRepository.AddResponseAsync(response);
        }

        public async Task UpdateResponseAsync(Response response)
        {
            await _responseRepository.UpdateResponseAsync(response);
        }

        public async Task DeleteResponseAsync(int studentId, int examId)
        {
            await _responseRepository.DeleteResponseAsync(studentId, examId);
        }
    }
}

