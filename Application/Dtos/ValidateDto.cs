namespace Application.Dtos
{
    public class ValidateDto
    {
        public int ExamId { get; set; }
        public int ProfessorId { get; set; }
        public string Observations { get; set; }
        public DateTime ValidationDate { get; set; }
    }
}
