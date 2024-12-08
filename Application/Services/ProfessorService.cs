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

        //public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        //{
        //    return await _professorRepository.GetAllProfessorsAsync();
        //}

        public async Task AddProfessorAsync(Professor professor)
        {
            await _professorRepository.AddProfessorAsync(professor);
        }

        //public async Task DeleteProfessorAsync(Professor professor)
        //{
        //    await _professorRepository.DeleteProfessorAsync(professor);
        //}

        //public async Task ClearProfessorsAsync()
        //{
        //    await _professorRepository.ClearProfessorsAsync();
        //}
    }
}
