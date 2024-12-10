using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<Admin>> GetAdminsAsync()
        {
            return await _adminRepository.GetAdminsAsync();
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _adminRepository.AddAdminAsync(admin);
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            await _adminRepository.UpdateAdminAsync(admin);
        }

        public async Task DeleteAdminAsync(int id)
        {
            await _adminRepository.DeleteAdminAsync(id);
        }
    }
}
