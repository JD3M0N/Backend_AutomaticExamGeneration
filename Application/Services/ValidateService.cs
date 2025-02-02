using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ValidateService : IValidateService
    {
        private readonly IValidateRepository _validateRepository;

        public ValidateService(IValidateRepository validateRepository)
        {
            _validateRepository = validateRepository;
        }

        public async Task<IEnumerable<ValidateDto>> GetAllValidationsAsync()
        {
            var validations = await _validateRepository.GetAllValidationsAsync();
            return validations.Select(v => new ValidateDto
            {
                ExamId = v.ExamId,
                ProfessorId = v.ProfessorId,
                Observations = v.Observations,
                ValidationDate = v.ValidationDate
            });
        }

        public async Task AddValidationAsync(ValidateDto validateDto)
        {
            var validation = new Validate
            {
                ExamId = validateDto.ExamId,
                ProfessorId = validateDto.ProfessorId,
                Observations = validateDto.Observations,
                ValidationDate = validateDto.ValidationDate
            };
            await _validateRepository.AddValidationAsync(validation);
        }
    }
}
