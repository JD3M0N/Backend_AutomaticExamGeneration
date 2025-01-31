using Domain.Entities;
using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITopicRepository
    {
        Task AddTopicAsync(Topic topic);
        Task<IEnumerable<TopicDto>> GetAllTopicsAsync();
        Task DeleteTopicAsync(int id);
        Task UpdateTopicAsync(Topic topic);
        Task<Topic> GetTopicByIdAsync(int id);
        Task<Topic> GetTopicByNameAsync(string name);
        Task<IEnumerable<TopicDto>> GetTopicsByProfessorIdAsync(int professorId);
    }
}
