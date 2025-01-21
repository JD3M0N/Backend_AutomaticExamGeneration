using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
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

        public async Task<IEnumerable<Professor>> GetProfessorsAsync()
        {
            return await _professorRepository.GetProfessorsAsync();
        }

        public async Task AddProfessorAsync(Professor professor)
        {
            await _professorRepository.AddProfessorAsync(professor);
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            await _professorRepository.UpdateProfessorAsync(professor);
        }

        public async Task DeleteProfessorAsync(int id)
        {
            await _professorRepository.DeleteProfessorAsync(id);
        }

        public async Task<Professor> GetProfessorByEmailAsync(string email)
        {
            return await _professorRepository.GetProfessorByEmailAsync(email);
        }
    }
}
