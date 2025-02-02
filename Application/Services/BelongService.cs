using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BelongService : IBelongService
    {
        private readonly IBelongRepository _belongRepository;

        public BelongService(IBelongRepository belongRepository)
        {
            _belongRepository = belongRepository;
        }

        public async Task<IEnumerable<BelongSimpleDto>> GetAllBelongsAsync()
        {
            var belongs = await _belongRepository.GetAllBelongsAsync();
            return belongs.Select(b => new BelongSimpleDto
            {
                Id = b.Id,
                QuestionId = b.QuestionId,
                ExamId = b.ExamId
            });
        }

        public async Task<BelongSimpleDto> GetBelongByIdAsync(int id)
        {
            var belong = await _belongRepository.GetBelongByIdAsync(id);
            if (belong == null)
            {
                return null;
            }

            return new BelongSimpleDto
            {
                Id = belong.Id,
                QuestionId = belong.QuestionId,
                ExamId = belong.ExamId
            };
        }

        public async Task AddBelongAsync(BelongDto belongDto)
        {
            var belong = new Belong
            {
                QuestionId = belongDto.Q_ID,
                ExamId = belongDto.X_ID
            };

            await _belongRepository.AddBelongAsync(belong);
            await _belongRepository.SaveChangesAsync();
        }

        public async Task UpdateBelongAsync(Belong belong)
        {
            await _belongRepository.UpdateBelongAsync(belong);
        }

        public async Task DeleteBelongAsync(int id)
        {
            await _belongRepository.DeleteBelongAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId)
        {
            return await _belongRepository.GetQuestionsByExamIdAsync(examId);
        }
    }
}
