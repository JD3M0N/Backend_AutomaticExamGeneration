using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEnrollService
    {
        Task EnrollStudentAsync(EnrollDto enrollDto);
        Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsByAssignmentIdAsync(int assignmentId);
        Task UnenrollStudentAsync(int studentId, int assignmentId);
    }
}