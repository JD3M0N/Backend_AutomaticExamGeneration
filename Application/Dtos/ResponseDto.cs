namespace Application.Dtos
{
    public class ResponseDto
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ResponseText { get; set; }
    }
}
