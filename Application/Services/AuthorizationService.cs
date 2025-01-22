using Application.Interfaces;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        public AuthorizationService(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }

        public async Task<bool> CanAddQuestionAsync(int professorId, int topicId)
        {
            return await _authorizationRepository.CanAddQuestionAsync(professorId, topicId);
        }
    }
}
