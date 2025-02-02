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

            // Write in console how many questions there are
            System.Console.WriteLine($"Hay {questions.Count()} preguntas.");

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question == null)
            {
                return NotFound("Pregunta no encontrada.");
            }

            // Write in console the question's text
            System.Console.WriteLine($"Pregunta: {question.QuestionText}");

            return Ok(question);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);

            //Write in console that a question has been deleted
            System.Console.WriteLine($"Pregunta con ID {id} eliminada.");

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

        [HttpGet("professor/{professorId}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByProfessor(int professorId)
        {
            var questions = await _questionService.GetQuestionsByProfessorIdAsync(professorId);
            if (questions == null || !questions.Any())
            {
                return NotFound("No se encontraron preguntas para este profesor.");
            }

            //Write in console how many questions this professor has
            System.Console.WriteLine($"El profesor {professorId} tiene {questions.Count()} preguntas.");    

            return Ok(questions);
        }

    }
}
