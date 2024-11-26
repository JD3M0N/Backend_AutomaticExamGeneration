using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || user.Password != password)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() 
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
