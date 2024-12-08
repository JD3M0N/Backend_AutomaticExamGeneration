using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        Task AddAdminAsync(Admin admin);
        //Task<IEnumerable<Admin>> GetAllAdminsAsync();
        //Task ClearAdminsAsync();
    }
}
