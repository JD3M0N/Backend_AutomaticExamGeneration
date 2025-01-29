using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int id);
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
        Task<Professor> GetProfessorByEmailAsync(string email);
        Task<bool> IsHeadOfAssignmentAsync(int professorId);
    }
}
