using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;
using Application.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
        {
            var question = new Question
            {
                Difficulty = questionDto.Difficulty,
                Type = questionDto.Type,
                QuestionText = questionDto.QuestionText,
                TopicId = questionDto.TopicId
            };
            await _questionService.AddQuestionAsync(question);
            return Ok(question);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody]  QuestionDto questionDto)
        {
            var question = new Question
            {
                Id = id,
                Difficulty = questionDto.Difficulty,
                Type = questionDto.Type,
                QuestionText = questionDto.QuestionText,
                TopicId = questionDto.TopicId
            };
            await _questionService.UpdateQuestionAsync(question);
            return Ok(question);
        }
    }
}
