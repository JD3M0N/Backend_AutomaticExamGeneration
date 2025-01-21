using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OwnService : IOwnService
    {
        private readonly IOwnRepository _ownRepository;

        public OwnService(IOwnRepository ownRepository)
        {
            _ownRepository = ownRepository;
        }

        public async Task AddOwnAsync(int assignmentId, int topicId)
        {
            var own = new Own
            {
                AssignmentId = assignmentId,
                TopicId = topicId
            };

            await _ownRepository.AddOwnAsync(own);
        }

        public async Task<IEnumerable<Own>> GetAllOwnsAsync()
        {
            return await _ownRepository.GetAllOwnsAsync();
        }

        public async Task<Own> GetOwnByIdAsync(int id)
        {
            return await _ownRepository.GetOwnByIdAsync(id);
        }

        public async Task UpdateOwnAsync(int id, int assignmentId, int topicId)
        {
            var own = await _ownRepository.GetOwnByIdAsync(id);
            if (own != null)
            {
                own.AssignmentId = assignmentId;
                own.TopicId = topicId;
                await _ownRepository.UpdateOwnAsync(own);
            }
        }

        public async Task DeleteOwnAsync(int id)
        {
            await _ownRepository.DeleteOwnAsync(id);
        }
    }
}
