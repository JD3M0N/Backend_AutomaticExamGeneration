using System;

namespace Infrastructure.Dtos
{
    public class ExamStatsDto
    {
        //name of creator, date, parameters
        public int ExamId { get; set; }
        public string ProfessorName { get; set; }
        public DateTime CreationDate { get; set; }
        public string PPT { get; set; }
        public string CT { get; set; }
        public string CTP { get; set; }
    }
}
