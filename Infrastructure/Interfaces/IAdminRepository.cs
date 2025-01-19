using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(int id);
        Task<Admin> GetAdminByEmailAsync(string email);
    }
}
