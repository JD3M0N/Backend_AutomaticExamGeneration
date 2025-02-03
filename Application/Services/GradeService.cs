using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<IEnumerable<GradeDto>> GetAllGradesAsync()
        {
            var grades = await _gradeRepository.GetAllGradesAsync();
            return grades.Select(g => new GradeDto
            {
                ProfessorId = g.ProfessorId,
                StudentId = g.StudentId,
                QuestionId = g.QuestionId,
                ExamId = g.ExamId,
                GradeValue = g.GradeValue
            });
        }

        public async Task<GradeDto> GetGradeByIdAsync(int id)
        {
            var grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (grade == null) return null;

            return new GradeDto
            {
                ProfessorId = grade.ProfessorId,
                StudentId = grade.StudentId,
                QuestionId = grade.QuestionId,
                ExamId = grade.ExamId,
                GradeValue = grade.GradeValue
            };
        }

        public async Task AddGradeAsync(GradeDto gradeDto)
        {
            var grade = new Grade
            {
                ProfessorId = gradeDto.ProfessorId,
                StudentId = gradeDto.StudentId,
                QuestionId = gradeDto.QuestionId,
                ExamId = gradeDto.ExamId,
                GradeValue = gradeDto.GradeValue
            };

            await _gradeRepository.AddGradeAsync(grade);
        }

        public async Task UpdateGradeAsync(int id, GradeDto gradeDto)
        {
            var grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (grade != null)
            {
                grade.ProfessorId = gradeDto.ProfessorId;
                grade.StudentId = gradeDto.StudentId;
                grade.QuestionId = gradeDto.QuestionId;
                grade.ExamId = gradeDto.ExamId;
                grade.GradeValue = gradeDto.GradeValue;

                await _gradeRepository.UpdateGradeAsync(grade);
            }
        }

        public async Task DeleteGradeAsync(int id)
        {
            await _gradeRepository.DeleteGradeAsync(id);
        }

        public async Task<string> GetStudentExamGradeAsync(int studentId, int examId)
        {
            return await _gradeRepository.GetStudentExamGradeAsync(studentId, examId);
        }

        public async Task<List<object>> GetStudentGradedExamsAsync(int studentId)
        {
            return await _gradeRepository.GetStudentGradedExamsAsync(studentId);
        }

        public async Task<List<object>> GetStudentGradesByAssignmentAsync(int studentId, int assignmentId)
        {
            return await _gradeRepository.GetStudentGradesByAssignmentAsync(studentId, assignmentId);
        }

    }
}
