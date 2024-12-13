namespace Application.Dtos
{
    public class ExamDto
    {
        public int AssignmentId { get; set; }
        public int ProfessorId { get; set; }
        public string PPT { get; set; }
        public string CT { get; set; }
        public string CTP { get; set; }
        public DateTime Date { get; set; }
    }
}
