using Application.Interfaces;
using Application.Dtos;
using Infrastructure.Interfaces;
//using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
//using BCrypt.Net;


namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITokenService _tokenService;

        public AuthService(
            IAdminRepository adminRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository,
            ITokenService tokenService)
        {
            _adminRepository = adminRepository;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthResultDto> AuthenticateAsync(LoginDto loginDto)
        {
            // Verificar en Admin
            var admin = await _adminRepository.GetAdminByEmailAsync(loginDto.Email);
            if (admin != null && VerifyPassword(loginDto.Password, admin.Password))
            {
                var token = _tokenService.GenerateToken(admin.Id, "Admin");
                return new AuthResultDto(true, "Admin", token);
            }

            // Verificar en Professor
            //var professor = await _professorRepository.GetProfessorByEmailAsync(loginDto.Email);
            //if (professor != null && VerifyPassword(loginDto.Password, professor.Password))
            //{
            //    var token = _tokenService.GenerateToken(professor.Id, "Professor");
            //    return new AuthResultDto(true, "Professor", token);
            //}

            // Verificar en Professor
            var professor = await _professorRepository.GetProfessorByEmailAsync(loginDto.Email);
            if (professor != null && VerifyPassword(loginDto.Password, professor.Password))
            {
                var token = _tokenService.GenerateToken(professor.Id, "Professor", professor.Id); // Pasa el professorId
                return new AuthResultDto(true, "Professor", token);
            }

            // Verificar en Student
            var student = await _studentRepository.GetStudentByEmailAsync(loginDto.Email);
            if (student != null && VerifyPassword(loginDto.Password, student.Password))
            {
                var token = _tokenService.GenerateToken(student.Id, "Student");
                return new AuthResultDto(true, "Student", token);
            }

            // Si no coincide con ningún usuario
            return new AuthResultDto(false, null, "Email o contraseña incorrectos.");
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
