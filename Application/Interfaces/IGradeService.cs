using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetAllGradesAsync();
        Task<GradeDto> GetGradeByIdAsync(int id);
        Task AddGradeAsync(GradeDto gradeDto);
        Task UpdateGradeAsync(int id, GradeDto gradeDto);
        Task DeleteGradeAsync(int id);
        Task<string> GetStudentExamGradeAsync(int studentId, int examId);
        Task<List<object>> GetStudentGradedExamsAsync(int studentId);
        Task<List<object>> GetStudentGradesByAssignmentAsync(int studentId, int assignmentId);
    }
}
