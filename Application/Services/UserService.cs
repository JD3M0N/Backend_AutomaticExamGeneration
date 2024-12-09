using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAdminRepository _adminRepository;

        public UserService(IUserRepository userRepository, IProfessorRepository professorRepository, IStudentRepository studentRepository, IAdminRepository adminRepository)
        {
            _userRepository = userRepository;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
            _adminRepository = adminRepository;
        }

        public async Task<User> AddUserAsync(string name, string lastName, string email, string rol, string password)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Rol = rol,
                Password = password
            };

            await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task ClearUsersAsync()
        {
            await _userRepository.ClearUsersAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
