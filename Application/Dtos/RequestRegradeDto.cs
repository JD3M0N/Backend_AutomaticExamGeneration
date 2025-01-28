namespace Application.Dtos
{
    public class RequestRegradeDto
    {
        public int ProfessorId { get; set; } // Foreign key to Professor
        public int StudentId { get; set; }   // Foreign key to Student
        public int QuestionId { get; set; }  // Foreign key to Question
        public int ExamId { get; set; }      // Foreign key to Exam
        public bool State { get; set; }      // Status: false = not reviewed, true = reviewed
    }
}
