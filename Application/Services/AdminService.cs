using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    //public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
    //{
    //    return await _adminRepository.GetAllAdminsAsync();
    //}

    //public async Task ClearAdminsAsync()
    //{
    //    await _adminRepository.ClearAdminsAsync();
    //}
}
