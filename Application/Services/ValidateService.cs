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
        private readonly IExamService _examService;

        public ValidateService(IValidateRepository validateRepository, IExamService examService)
        {
            _validateRepository = validateRepository;
            _examService = examService;
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
                ValidationDate = validateDto.ValidationDate,
                ValidationState = validateDto.ValidationState
            };

            await _validateRepository.AddValidationAsync(validation);

            // Determinar estado del examen
            string newState = validation.ValidationState ? "validated" : "denied";

            // Llamar al servicio de examen para actualizar el estado
            await _examService.UpdateExamStateAsync(validateDto.ExamId, newState);
        }
    }
}
