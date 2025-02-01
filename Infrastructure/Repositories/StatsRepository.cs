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
    }
}
