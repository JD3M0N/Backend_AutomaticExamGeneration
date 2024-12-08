using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
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
            if (rol != "Admin" && rol != "Professor" && rol != "Student")
            {
                throw new ArgumentException("Invalid role specified.");
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Rol = rol
            };

            await _userRepository.AddUserAsync(user);

            if (rol == "Professor")
            {
                var professor = new Professor
                {
                    Id = user.Id,
                    Name = $"{name} {lastName}",
                    Speciality = "Default Speciality"
                };
                await _professorRepository.AddProfessorAsync(professor);
            }
            else if (rol == "Student")
            {
                var student = new Student
                {
                    Id = user.Id,
                    Name = $"{name} {lastName}",
                    Age = 0, // Default value, you can change it as needed
                    Grade = 0 // Default value, you can change it as needed
                };
                await _studentRepository.AddStudentAsync(student);
            }
            else if (rol == "Admin")
            {
                var admin = new Admin
                {
                    Id = user.Id,
                    Name = $"{name} {lastName}",
                    Email = email,
                    Password = password
                };
                await _adminRepository.AddAdminAsync(admin);
            }

            return user;
        }


        public async Task ClearUsersAsync()
        {
            await _userRepository.ClearUsersAsync();
        }
    }
}
