using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEnrollRepository
    {
        Task AddEnrollAsync(Enroll enroll);
        Task<IEnumerable<Assignment>> GetAssignmentsByStudentIdAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsByAssignmentIdAsync(int assignmentId);
        Task DeleteEnrollAsync(int studentId, int assignmentId);
    }
}