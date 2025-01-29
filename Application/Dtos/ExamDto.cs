namespace Application.Dtos
{
    public class ExamDto
    {
        public int AssignmentId { get; set; }
        public int ProfessorId { get; set; }
        public DateTime Date { get; set; }
        public int TotalQuestions { get; set; }
        public int Difficulty { get; set; }
        public int? TopicLimit { get; set; }
        public string State { get; set; }
    }

}
