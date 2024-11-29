using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task AddProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(Professor professor);
        Task ClearProfessorsAsync();
    }
}
