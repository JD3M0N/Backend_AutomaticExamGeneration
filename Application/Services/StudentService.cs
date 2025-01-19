using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollService _enrollService;

        public StudentService(IStudentRepository studentRepository, IEnrollService enrollService)
        {
            _studentRepository = studentRepository;
            _enrollService = enrollService;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
