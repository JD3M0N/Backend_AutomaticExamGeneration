using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IValidateRepository
    {
        Task<IEnumerable<Validate>> GetAllValidationsAsync();
        Task AddValidationAsync(Validate validation);
    }
}
