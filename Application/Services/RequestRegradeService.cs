using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RequestRegradeService : IRequestRegradeService
    {
        private readonly IRequestRegradeRepository _requestRegradeRepository;

        public RequestRegradeService(IRequestRegradeRepository requestRegradeRepository)
        {
            _requestRegradeRepository = requestRegradeRepository;
        }

        public async Task<IEnumerable<RequestRegradeDto>> GetAllRequestRegradesAsync()
        {
            var requestRegrades = await _requestRegradeRepository.GetAllRequestRegradesAsync();
            return requestRegrades.Select(rr => new RequestRegradeDto
            {
                ProfessorId = rr.ProfessorId,
                StudentId = rr.StudentId,
                QuestionId = rr.QuestionId,
                ExamId = rr.ExamId,
                State = rr.State
            });
        }

        public async Task<RequestRegradeDto> GetRequestRegradeByIdAsync(int id)
        {
            var requestRegrade = await _requestRegradeRepository.GetRequestRegradeByIdAsync(id);
            if (requestRegrade == null) return null;

            return new RequestRegradeDto
            {
                ProfessorId = requestRegrade.ProfessorId,
                StudentId = requestRegrade.StudentId,
                QuestionId = requestRegrade.QuestionId,
                ExamId = requestRegrade.ExamId,
                State = requestRegrade.State
            };
        }

        public async Task AddRequestRegradeAsync(RequestRegradeDto requestRegradeDto)
        {
            var requestRegrade = new RequestRegrade
            {
                ProfessorId = requestRegradeDto.ProfessorId,
                StudentId = requestRegradeDto.StudentId,
                QuestionId = requestRegradeDto.QuestionId,
                ExamId = requestRegradeDto.ExamId,
                State = requestRegradeDto.State
            };

            await _requestRegradeRepository.AddRequestRegradeAsync(requestRegrade);
        }

        public async Task UpdateRequestRegradeAsync(int id, RequestRegradeDto requestRegradeDto)
        {
            var requestRegrade = await _requestRegradeRepository.GetRequestRegradeByIdAsync(id);
            if (requestRegrade != null)
            {
                requestRegrade.ProfessorId = requestRegradeDto.ProfessorId;
                requestRegrade.StudentId = requestRegradeDto.StudentId;
                requestRegrade.QuestionId = requestRegradeDto.QuestionId;
                requestRegrade.ExamId = requestRegradeDto.ExamId;
                requestRegrade.State = requestRegradeDto.State;

                await _requestRegradeRepository.UpdateRequestRegradeAsync(requestRegrade);
            }
        }

        public async Task DeleteRequestRegradeAsync(int id)
        {
            await _requestRegradeRepository.DeleteRequestRegradeAsync(id);
        }
    }
}
