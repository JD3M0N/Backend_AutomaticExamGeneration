using Application.Dtos;
using Infrastructure.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeachService : ITeachService
    {
        private readonly ITeachRepository _teachRepository;

        public TeachService(ITeachRepository teachRepository)
        {
            _teachRepository = teachRepository;
        }

        public async Task<IEnumerable<TeachDto>> GetTeachesAsync()
        {
            return await _teachRepository.GetTeachesAsync();
        }


        public async Task AddTeachAsync(Teach teach)
        {
            await _teachRepository.AddTeachAsync(teach);
        }

        public async Task DeleteTeachAsync(int id)
        {
            await _teachRepository.DeleteTeachAsync(id);
        }
        public async Task<IEnumerable<TeachDto>> GetAssignmentsByProfessorIdAsync(int professorId)
        {
            return await _teachRepository.GetAssignmentsByProfessorIdAsync(professorId);
        }
        public async Task<IEnumerable<Professor>> GetProfessorsByAssignmentIdAsync(int assignmentId)
        {
            return await _teachRepository.GetProfessorsByAssignmentIdAsync(assignmentId);
        }
    }
}
