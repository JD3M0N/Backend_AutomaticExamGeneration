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

        public UserService(IUserRepository userRepository, IProfessorRepository professorRepository, IStudentRepository studentRepository)
        {
            _userRepository = userRepository;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
        }

        public async Task<User> AddUserAsync(string name, string lastName, string email, string password, string rol)
        {
            var user = new User
            {
                Name = name,
                LastName = lastName,
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
                    Name = $"{name} {lastName}"
                };
                await _studentRepository.AddStudentAsync(student);
            }

            return user;
        }

        public async Task ClearUsersAsync()
        {
            await _userRepository.ClearUsersAsync();
        }
    }
}
