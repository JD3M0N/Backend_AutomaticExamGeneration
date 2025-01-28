namespace Application.Dtos
{
    public class RegradeDto
    {
        public int ProfessorId { get; set; } // Foreign key to Professor
        public int StudentId { get; set; }   // Foreign key to Student
        public int QuestionId { get; set; }  // Foreign key to Question
        public int ExamId { get; set; }      // Foreign key to Exam
        public int GradeValue { get; set; }  // Recalibrated grade
    }
}
