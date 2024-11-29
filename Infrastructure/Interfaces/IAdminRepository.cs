using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAdminRepository
{
    Task<IEnumerable<Admin>> GetAllAdminsAsync();
    Task ClearAdminsAsync();
}
