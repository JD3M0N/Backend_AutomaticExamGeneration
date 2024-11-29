using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
    }
}
