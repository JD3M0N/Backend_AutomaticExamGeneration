using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
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

        public async Task AddTopicAsync(string name)
        {
            var topic = new Topic
            {
                Name = name
            };

            await _topicRepository.AddTopicAsync(topic);
        }

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await _topicRepository.GetAllTopicsAsync();
        }

        public async Task DeleteTopicAsync(int id)
        {
            await _topicRepository.DeleteTopicAsync(id);
        }

        public async Task UpdateTopicAsync(int id, string name)
        {
            var topic = await _topicRepository.GetTopicByIdAsync(id);
            if (topic != null)
            {
                topic.Name = name;
                await _topicRepository.UpdateTopicAsync(topic);
            }
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _topicRepository.GetTopicByIdAsync(id);
        }
    }
}
