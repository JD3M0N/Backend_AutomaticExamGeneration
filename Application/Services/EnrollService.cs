using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services
{
    public class EnrollService : IEnrollService
    {
        private readonly IEnrollRepository _enrollRepository;

        public EnrollService(IEnrollRepository enrollRepository)
        {
            _enrollRepository = enrollRepository;
        }

        public async Task EnrollStudentAsync(EnrollDto enrollDto)
        {
            var enroll = new Enroll
            {
                StudentId = enrollDto.S_ID,
                AssignmentId = enrollDto.A_ID,
            };
            await _enrollRepository.AddEnrollAsync(enroll);
        }

        public async Task<IEnumerable<Assignment>> GetStudentAssignmentsAsync(int studentId)
        {
            return await _enrollRepository.GetAssignmentsByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentsByAssignmentIdAsync(int assignmentId)
        {
            return await _enrollRepository.GetStudentsByAssignmentIdAsync(assignmentId);
        }


        public async Task UnenrollStudentAsync(int studentId, int assignmentId)
        {
            await _enrollRepository.DeleteEnrollAsync(studentId, assignmentId);
        }
    }
}