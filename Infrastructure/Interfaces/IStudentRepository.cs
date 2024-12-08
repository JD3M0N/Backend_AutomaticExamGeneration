using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        //Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student student);
        //Task ClearStudentsAsync();
    }
}
