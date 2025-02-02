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

        public async Task<IEnumerable<UnusedQuestionDto>> GetUnusedQuestionsAsync()
        {
            // Fecha límite: hace 2 años desde hoy
            DateTime twoYearsAgo = DateTime.UtcNow.AddYears(-2);

            // Obtener todas las preguntas que NO han sido usadas en exámenes en los últimos 2 años
            var unusedQuestions = await (from q in _context.Questions
                                         join t in _context.Topic on q.TopicId equals t.Id
                                         join p in _context.Professor on q.ProfessorId equals p.Id
                                         where !(from b in _context.Belong
                                                 join e in _context.Exam on b.ExamId equals e.Id
                                                 where e.Date >= twoYearsAgo
                                                 select b.QuestionId)
                                                 .Contains(q.Id)
                                         select new UnusedQuestionDto
                                         {
                                             QuestionId = q.Id,
                                             QuestionText = q.QuestionText,
                                             Difficulty = q.Difficulty,
                                             TopicName = t.Name,
                                             ProfessorName = p.Name
                                         })
                                         .OrderBy(q => q.TopicName) // Ordenar por tema
                                         .ToListAsync();

            return unusedQuestions;
        }

        //public async Task<IEnumerable<ExamComparisonDto>> CompareExamsAcrossAssignmentsAsync()
        //{
        //    var examData = await (from e in _context.Exam
        //                          join a in _context.Assignment on e.AssignmentId equals a.Id
        //                          join b in _context.Belong on e.Id equals b.ExamId
        //                          join q in _context.Questions on b.QuestionId equals q.Id
        //                          join t in _context.Topic on q.TopicId equals t.Id
        //                          group new { e, q, t } by new { a.Id, a.Name } into grouped
        //                          select new
        //                          {
        //                              AssignmentName = grouped.Key.Name,
        //                              AverageDifficulty = grouped.Average(x => x.e.Difficulty),
        //                              TopicDistribution = grouped
        //                                  .GroupBy(x => x.t.Name)
        //                                  .Select(g => new
        //                                  {
        //                                      Topic = g.Key,
        //                                      Percentage = (double)g.Count() / grouped.Count() * 100
        //                                  })
        //                                  .ToDictionary(x => x.Topic, x => x.Percentage)
        //                          })
        //                          .ToListAsync();

        //    return examData.Select(d => new ExamComparisonDto
        //    {
        //        AssignmentName = d.AssignmentName,
        //        AverageDifficulty = d.AverageDifficulty,
        //        TopicDistribution = d.TopicDistribution
        //    });
        //}

        public async Task<IEnumerable<ExamComparisonDto>> CompareExamsAcrossAssignmentsAsync()
        {
            var examData = await (from e in _context.Exam
                                  join a in _context.Assignment on e.AssignmentId equals a.Id
                                  join b in _context.Belong on e.Id equals b.ExamId
                                  join q in _context.Questions on b.QuestionId equals q.Id
                                  join t in _context.Topic on q.TopicId equals t.Id
                                  select new
                                  {
                                      AssignmentId = a.Id,
                                      AssignmentName = a.Name,
                                      TopicName = t.Name,
                                      QuestionId = q.Id,
                                      ExamDifficulty = e.Difficulty
                                  })
                                  .ToListAsync(); // Se trae a memoria antes de construir el diccionario

            // Procesamiento en memoria
            var groupedData = examData
                .GroupBy(x => new { x.AssignmentId, x.AssignmentName })
                .Select(g => new ExamComparisonDto
                {
                    AssignmentName = g.Key.AssignmentName,
                    AverageDifficulty = g.Average(x => x.ExamDifficulty), // Dificultad promedio
                    TopicDistribution = g.GroupBy(x => x.TopicName)
                                         .ToDictionary(
                                             t => t.Key,
                                             t => (double)t.Count() / g.Count() * 100 // % de preguntas por tema
                                         )
                })
                .ToList();

            return groupedData;
        }
    }
}
