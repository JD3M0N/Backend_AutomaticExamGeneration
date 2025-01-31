using Domain.Entities;
using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITopicService
    {
        Task AddTopicAsync(string name, int assignmentId);
        Task<IEnumerable<TopicDto>> GetAllTopicsAsync();
        Task DeleteTopicAsync(int id);
        Task UpdateTopicAsync(int id, string name, int assignmentId);
        Task<TopicDto> GetTopicByIdAsync(int id);
        Task<int?> GetTopicIdByNameAsync(string name);
        Task<IEnumerable<TopicDto>> GetTopicsByProfessorIdAsync(int professorId);
    }
}
