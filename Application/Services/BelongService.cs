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
    }

}
