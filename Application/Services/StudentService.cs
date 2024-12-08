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

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //public async Task<IEnumerable<Student>> GetStudentsAsync()
        //{
        //    return await _studentRepository.GetStudentsAsync();
        //}

        //public async Task AddStudentAsync(Student student)
        //{
        //    await _studentRepository.AddStudentAsync(student);
        //}

        //public async Task ClearStudentsAsync()
        //{
        //    await _studentRepository.ClearStudentsAsync();
        //}
    }
}
