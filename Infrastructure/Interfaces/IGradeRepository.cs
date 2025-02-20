﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task AddGradeAsync(Grade grade);
        Task UpdateGradeAsync(Grade grade);
        Task DeleteGradeAsync(int id);
        Task<string> GetStudentExamGradeAsync(int studentId, int examId);
        Task<List<object>> GetStudentGradedExamsAsync(int studentId);
        Task<List<object>> GetStudentGradesByAssignmentAsync(int studentId, int assignmentId);
    }
}
