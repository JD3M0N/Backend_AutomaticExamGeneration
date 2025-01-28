using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegradeService : IRegradeService
    {
        private readonly IRegradeRepository _regradeRepository;

        public RegradeService(IRegradeRepository regradeRepository)
        {
            _regradeRepository = regradeRepository;
        }

        public async Task<IEnumerable<RegradeDto>> GetAllRegradesAsync()
        {
            var regrades = await _regradeRepository.GetAllRegradesAsync();
            return regrades.Select(r => new RegradeDto
            {
                ProfessorId = r.ProfessorId,
                StudentId = r.StudentId,
                QuestionId = r.QuestionId,
                ExamId = r.ExamId,
                GradeValue = r.GradeValue
            });
        }

        public async Task<RegradeDto> GetRegradeByIdAsync(int id)
        {
            var regrade = await _regradeRepository.GetRegradeByIdAsync(id);
            if (regrade == null) return null;

            return new RegradeDto
            {
                ProfessorId = regrade.ProfessorId,
                StudentId = regrade.StudentId,
                QuestionId = regrade.QuestionId,
                ExamId = regrade.ExamId,
                GradeValue = regrade.GradeValue
            };
        }

        public async Task AddRegradeAsync(RegradeDto regradeDto)
        {
            var regrade = new Regrade
            {
                ProfessorId = regradeDto.ProfessorId,
                StudentId = regradeDto.StudentId,
                QuestionId = regradeDto.QuestionId,
                ExamId = regradeDto.ExamId,
                GradeValue = regradeDto.GradeValue
            };

            await _regradeRepository.AddRegradeAsync(regrade);
        }

        public async Task UpdateRegradeAsync(int id, RegradeDto regradeDto)
        {
            var regrade = await _regradeRepository.GetRegradeByIdAsync(id);
            if (regrade != null)
            {
                regrade.ProfessorId = regradeDto.ProfessorId;
                regrade.StudentId = regradeDto.StudentId;
                regrade.QuestionId = regradeDto.QuestionId;
                regrade.ExamId = regradeDto.ExamId;
                regrade.GradeValue = regradeDto.GradeValue;

                await _regradeRepository.UpdateRegradeAsync(regrade);
            }
        }

        public async Task DeleteRegradeAsync(int id)
        {
            await _regradeRepository.DeleteRegradeAsync(id);
        }
    }
}
