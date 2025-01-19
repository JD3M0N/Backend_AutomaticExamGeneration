using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollService : IEnrollService
    {
        private readonly IEnrollRepository _enrollRepository;

        public EnrollService(IEnrollRepository enrollRepository)
        {
            _enrollRepository = enrollRepository;
        }

        public async Task EnrollStudentAsync(int studentId, int assignmentId)
        {
            var enroll = new Enroll
            {
                StudentId = studentId,
                AssignmentId = assignmentId
            };
            await _enrollRepository.AddEnrollAsync(enroll);
        }

        public async Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(int studentId)
        {
            return await _enrollRepository.GetAssignmentsByStudentIdAsync(studentId);
        }

        public async Task UnenrollStudentAsync(int studentId, int assignmentId)
        {
            await _enrollRepository.DeleteEnrollAsync(studentId, assignmentId);
        }
    }
}
