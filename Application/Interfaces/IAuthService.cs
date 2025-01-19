using Application.Dtos;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> AuthenticateAsync(LoginDto loginDto);
    }
}
