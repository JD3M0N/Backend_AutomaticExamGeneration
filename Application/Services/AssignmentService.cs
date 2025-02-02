using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync()
        {
            return await _assignmentRepository.GetAssignmentsAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetAssignmentByIdAsync(id);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await _assignmentRepository.AddAssignmentAsync(assignment);
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            await _assignmentRepository.UpdateAssignmentAsync(assignment);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            await _assignmentRepository.DeleteAssignmentAsync(id);
        }
        public async Task<int?> GetAssignmentIdByNameAsync(string name)
        {
            var assignment = await _assignmentRepository.GetAssignmentByNameAsync(name);
            return assignment?.Id;
        }
        public async Task<IEnumerable<Exam>> GetExamsByAssignmentIdAsync(int assignmentId)
        {
            return await _assignmentRepository.GetExamsByAssignmentIdAsync(assignmentId);
        }

        public async Task<IEnumerable<Topic>> GetTopicsByAssignmentIdAsync(int assignmentId)
        {
            return await _assignmentRepository.GetTopicsByAssignmentIdAsync(assignmentId);
        }

    }
}
