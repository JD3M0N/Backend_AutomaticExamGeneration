using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidateUserAsync(string email, string password);
        Task<IEnumerable<User>> GetAllUsersAsync(); 
    }
}
