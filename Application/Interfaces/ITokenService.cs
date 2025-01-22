namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string userType, int? professorId = null);
    }
}
