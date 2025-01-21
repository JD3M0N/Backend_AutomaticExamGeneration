using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITopicService
    {
        Task AddTopicAsync(string name);
        Task<IEnumerable<Topic>> GetAllTopicsAsync();
        Task DeleteTopicAsync(int id);
        Task UpdateTopicAsync(int id, string name);
        Task<Topic> GetTopicByIdAsync(int id);
        Task<int?> GetTopicIdByNameAsync(string name);
    }
}
