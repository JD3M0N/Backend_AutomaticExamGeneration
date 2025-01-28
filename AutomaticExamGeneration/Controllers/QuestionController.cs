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
        private readonly IAuthorizationService _authorizationService;

        public QuestionController(IQuestionService questionService, IAuthorizationService authorizationService)
        {
            _questionService = questionService;
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDto questionDto)
        {
            // Simula que recibes el ID del profesor desde el DTO o el token de autenticación
            //int professorId = questionDto.ProfessorId;

            // Verifica si el profesor tiene permiso para añadir preguntas a este tema
            bool canAdd = await _authorizationService.CanAddQuestionAsync(questionDto.ProfessorId, questionDto.TopicId);

            if (!canAdd)
            {
                //Write in console what professor can't add what topic
                System.Console.WriteLine($"El profesor {questionDto.ProfessorId} no tiene permiso para añadir preguntas al tema {questionDto.TopicId}");
                return Unauthorized("No tienes permiso para añadir preguntas a este tema.");
            }

            // Si tiene permiso, procede a crear la pregunta
            var question = new Question
            {
                Difficulty = questionDto.Difficulty,
                Type = questionDto.Type,
                QuestionText = questionDto.QuestionText,
                TopicId = questionDto.TopicId,
                ProfessorId = questionDto.ProfessorId
            };

            await _questionService.AddQuestionAsync(question);

            //Write in console that a question has been added, by what professor to what topic
            System.Console.WriteLine($"Pregunta añadida por profesor {questionDto.ProfessorId} al tema {questionDto.TopicId}");
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
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDto questionDto)
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
