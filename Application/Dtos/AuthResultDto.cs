namespace Application.Dtos
{
    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string UserType { get; set; }
        public int? ProfessorId { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

        public AuthResultDto(bool success, string userType, string token = null, string message = null)
        {
            Success = success;
            UserType = userType;
            Token = token;
            Message = message;
        }

        public AuthResultDto(bool success, string userType, int professorId, string token = null, string message = null)
        {
            Success = success;
            UserType = userType;
            ProfessorId = professorId;
            Token = token;
            Message = message;
        }
    }
}
