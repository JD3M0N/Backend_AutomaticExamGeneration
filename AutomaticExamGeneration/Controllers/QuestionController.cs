using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;

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
            await _questionService.AddQuestionAsync(questionDto.Difficulty, questionDto.Type, questionDto.QuestionText, questionDto.TopicId);
            return Ok();
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
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionDto updateQuestionDto)
        {
            await _questionService.UpdateQuestionAsync(id, updateQuestionDto.Difficulty, updateQuestionDto.Type, updateQuestionDto.QuestionText);
            return Ok();
        }
    }

    public class QuestionDto
    {
        public int Difficulty { get; set; }
        public string Type { get; set; }
        public string QuestionText { get; set; }
        public int TopicId { get; set; }
    }

    public class UpdateQuestionDto
    {
        public int Difficulty { get; set; }
        public string Type { get; set; }
        public string QuestionText { get; set; }
    }
}
