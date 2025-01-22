using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<bool> CanAddQuestionAsync(int professorId, int topicId);
    }
}
