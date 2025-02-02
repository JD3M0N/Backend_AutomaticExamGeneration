using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int professorId);
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
        Task<Professor> GetProfessorByEmailAsync(string email);
        Task<IEnumerable<Exam>> GetUnvalidatedExamsByProfessorIdAsync(int professorId);

    }
}
