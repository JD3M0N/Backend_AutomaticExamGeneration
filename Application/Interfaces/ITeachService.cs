using Domain.Entities;
using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeachService
    {
        Task<IEnumerable<TeachDto>> GetTeachesAsync();
        Task AddTeachAsync(Teach teach);
        Task DeleteTeachAsync(int id);
        Task<IEnumerable<TeachDto>> GetAssignmentsByProfessorIdAsync(int professorId);
        Task<IEnumerable<Professor>> GetProfessorsByAssignmentIdAsync(int assignmentId);
    }
}
