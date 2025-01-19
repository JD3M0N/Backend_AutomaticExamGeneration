using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEnrollService
    {
        Task EnrollStudentAsync(int studentId, int assignmentId);
        Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(int studentId);
        Task UnenrollStudentAsync(int studentId, int assignmentId);
    }
}
