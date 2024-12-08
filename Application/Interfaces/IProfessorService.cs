using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task AddProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(Professor professor);
        Task ClearProfessorsAsync();
    }
}
