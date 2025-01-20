using Application.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IStudentRepository _studentRepository;

        public UserValidationService(
            IAdminRepository adminRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            // Verificar en la tabla Admin
            if (await _adminRepository.GetAdminByEmailAsync(email) != null)
                return true;

            // Verificar en la tabla Professor
            if (await _professorRepository.GetProfessorByEmailAsync(email) != null)
                return true;

            // Verificar en la tabla Student
            if (await _studentRepository.GetStudentByEmailAsync(email) != null)
                return true;

            return false; // El correo no existe en ninguna tabla
        }
    }
}