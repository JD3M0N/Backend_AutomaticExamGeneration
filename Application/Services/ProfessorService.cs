using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _professorRepository.GetAllProfessorsAsync();
        }
    }
}
