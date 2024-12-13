using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;

        public ResponseService (IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }
        public async Task AddResponseAsync(Response response)
        {
            await _responseRepository.AddResponseAsync(response);
        }

        public async Task DeleteResponseAsync(int id)
        {
            await _responseRepository.DeleteResponseAsync(id);
        }

        public async Task<IEnumerable<Response>> GetResponseAsync()
        {
            return await _responseRepository.GetResponseAsync();
        }

        public async Task UpdateResponseAsync(Response response)
        {
            await _responseRepository.UpdateResponseAsync(response);
        }
    }
}
