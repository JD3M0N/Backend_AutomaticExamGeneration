using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthorizationService
    {
        Task<bool> CanAddQuestionAsync(int professorId, int topicId);
    }
}
