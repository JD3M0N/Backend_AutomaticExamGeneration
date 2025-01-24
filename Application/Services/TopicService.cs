using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task AddTopicAsync(string name, int assignmentId)
        {
            var topic = new Topic
            {
                Name = name,
                AssignmentId = assignmentId 
            };

            await _topicRepository.AddTopicAsync(topic);
        }

        public async Task<IEnumerable<TopicDto>> GetAllTopicsAsync()
        {
            return await _topicRepository.GetAllTopicsAsync();
        }

        public async Task DeleteTopicAsync(int id)
        {
            await _topicRepository.DeleteTopicAsync(id);
        }

        public async Task UpdateTopicAsync(int id, string name, int assignmentId)
        {
            // Buscar el Topic existente en el repositorio
            var topic = await _topicRepository.GetTopicByIdAsync(id);

            if (topic != null)
            {
                // Actualizar las propiedades del Topic
                topic.Name = name;
                topic.AssignmentId = assignmentId;

                // Llamar al repositorio para actualizar la entidad
                await _topicRepository.UpdateTopicAsync(topic);
            }
        }

        public async Task<TopicDto> GetTopicByIdAsync(int id)
        {
            var topic = await _topicRepository.GetTopicByIdAsync(id);
            if (topic == null) return null;

            return new TopicDto
            {
                Name = topic.Name,
                AssignmentId = topic.AssignmentId,
                AssignmentName = topic.Assignment?.Name
            };
        }


        public async Task<int?> GetTopicIdByNameAsync(string name)
        {
            var topic = await _topicRepository.GetTopicByNameAsync(name);
            return topic?.Id;
        }
    }
}
