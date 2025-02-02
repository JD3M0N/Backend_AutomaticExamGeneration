using Domain.Entities;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        private readonly ApplicationDbContext _context;

        public StatsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId)
        {
            return await _context.Exam
                .Where(e => e.AssignmentId == assignmentId)
                .Select(e => new ExamStatsDto
                {
                    ExamId = e.Id,
                    ProfessorName = e.Professor.Name,
                    CreationDate = e.Date,
                    TotalQuestions = e.TotalQuestions,
                    Difficulty = e.Difficulty,
                    TopicLimit = e.TopicLimit,
                    State = e.State
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentNameAsync(string assignmentName)
        {
            var result = await (from e in _context.Exam
                                join a in _context.Assignment on e.AssignmentId equals a.Id
                                join p in _context.Professor on a.ProfessorId equals p.Id
                                where a.Name == assignmentName
                                select new ExamStatsDto
                                {
                                    ExamId = e.Id,
                                    ProfessorName = p.Name,
                                    CreationDate = e.Date,
                                    TotalQuestions = e.TotalQuestions,
                                    Difficulty = e.Difficulty,
                                    TopicLimit = e.TopicLimit
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<QuestionUsageStatsDto>> GetMostUsedQuestionsAsync(int assignmentId)
        {
            return await (from eq in _context.Belong
                          join q in _context.Questions on eq.QuestionId equals q.Id
                          join t in _context.Topic on q.TopicId equals t.Id
                          join e in _context.Exam on eq.ExamId equals e.Id
                          where e.AssignmentId == assignmentId
                          group q by new { q.Id, q.QuestionText, q.Difficulty, t.Name } into g
                          orderby g.Count() descending, g.Key.Difficulty, g.Key.Name
                          select new QuestionUsageStatsDto
                          {
                              QuestionId = g.Key.Id,
                              QuestionText = g.Key.QuestionText,
                              Difficulty = g.Key.Difficulty,
                              TopicName = g.Key.Name,
                              UsageCount = g.Count()
                          }).ToListAsync();
        }

        public async Task<IEnumerable<ValidatedExamDto>> GetValidatedExamsByProfessorAsync(int professorId)
        {
            return await (from v in _context.Validate
                          join e in _context.Exam on v.ExamId equals e.Id
                          join a in _context.Assignment on e.AssignmentId equals a.Id
                          where v.ProfessorId == professorId
                          select new ValidatedExamDto
                          {
                              ExamId = e.Id,
                              AssignmentName = a.Name,
                              ValidationDate = v.ValidationDate,
                              Observations = v.Observations
                          })
                          .ToListAsync();
        }

        public async Task<IEnumerable<ExamPerformanceDto>> GetExamPerformanceAsync(int examId)
        {
            return await (from g in _context.Grades
                          join q in _context.Questions on g.QuestionId equals q.Id
                          where g.ExamId == examId
                          group g by new { q.Id, q.QuestionText, q.Difficulty } into grouped
                          select new ExamPerformanceDto
                          {
                              ExamId = examId,
                              QuestionText = grouped.Key.QuestionText,
                              Difficulty = grouped.Key.Difficulty,
                              TotalResponses = grouped.Count(),
                              CorrectResponses = grouped.Count(g => g.GradeValue > 2),
                              IncorrectResponses = grouped.Count(g => g.GradeValue <= 2),
                              AccuracyRate = grouped.Count() > 0
                                  ? (double)grouped.Count(g => g.GradeValue > 2) / grouped.Count() * 100
                                  : 0
                          })
                          .OrderByDescending(e => e.AccuracyRate) // Ordenar por tasa de acierto descendente
                          .ToListAsync();
        }
    }
}
