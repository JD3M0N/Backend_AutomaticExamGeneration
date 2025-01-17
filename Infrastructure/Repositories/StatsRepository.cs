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
                    PPT = e.PPT,
                    CT = e.CT,
                    CTP = e.CTP
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
                                    PPT = e.PPT,
                                    CT = e.CT,
                                    CTP = e.CTP
                                }).ToListAsync();

            return result;
        }
    }
}
