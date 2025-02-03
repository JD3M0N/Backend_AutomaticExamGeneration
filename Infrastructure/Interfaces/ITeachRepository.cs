using Domain.Entities;
using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITeachRepository
    {
        Task<IEnumerable<TeachDto>> GetTeachesAsync();
        Task AddTeachAsync(Teach teach);
        Task DeleteTeachAsync(int id);
        Task<IEnumerable<TeachDto>> GetAssignmentsByProfessorIdAsync(int professorId);
        Task<IEnumerable<Professor>> GetProfessorsByAssignmentIdAsync(int assignmentId);
    }
}
