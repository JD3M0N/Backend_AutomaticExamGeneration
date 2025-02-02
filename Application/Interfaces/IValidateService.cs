using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IValidateService
    {
        Task<IEnumerable<ValidateDto>> GetAllValidationsAsync();
        Task AddValidationAsync(ValidateDto validateDto);
    }
}
