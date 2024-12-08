using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProfessorRepository
    {
        Task AddProfessorAsync(Professor professor);
    }
}
