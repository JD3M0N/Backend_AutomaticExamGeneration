using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services;
using Infrastructure.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnController : ControllerBase
    {
        private readonly IOwnService _ownService;
        private readonly IAssignmentService _assignmentService;
        private readonly ITopicService _topicService;

        public OwnController(IOwnService ownService, IAssignmentService assignmentService, ITopicService topicService)
        {
            _ownService = ownService;
            _assignmentService = assignmentService;
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOwn([FromBody] OwnDto ownDto)
        {
            await _ownService.AddOwnAsync(ownDto.AssignmentId, ownDto.TopicId);
            return Ok();
        }

        [HttpPost("add-by-names")]
        public async Task<IActionResult> AddOwnByNames([FromBody] OwnByNamesDto ownByNamesDto)
        {
            //Check if empty
            if (ownByNamesDto == null || string.IsNullOrEmpty(ownByNamesDto.AssignmentName) || string.IsNullOrEmpty(ownByNamesDto.TopicName))
                return BadRequest("Invalid data.");

            //Search for the assignment by name
            var assignmentId = await _assignmentService.GetAssignmentIdByNameAsync(ownByNamesDto.AssignmentName);
            if (assignmentId == null)
                return NotFound("Assignment with the given name not found.");

            //Search for the topic by name
            var topicId = await _topicService.GetTopicIdByNameAsync(ownByNamesDto.TopicName);
            if (topicId == null)
                return NotFound("Topic with the given name not found.");

            //Create a new Own entry
            await _ownService.AddOwnAsync(assignmentId.Value, topicId.Value);

            //Write in the console the assignment name and the topic name
            Console.WriteLine($"{ownByNamesDto.AssignmentName} owns {ownByNamesDto.TopicName}");

            return Ok("Own entry added successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Own>>> GetAllOwns()
        {
            var owns = await _ownService.GetAllOwnsAsync();
            return Ok(owns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Own>> GetOwnById(int id)
        {
            var own = await _ownService.GetOwnByIdAsync(id);
            if (own == null)
            {
                return NotFound();
            }
            return Ok(own);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwn(int id, [FromBody] OwnDto ownDto)
        {
            await _ownService.UpdateOwnAsync(id, ownDto.AssignmentId, ownDto.TopicId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwn(int id)
        {
            await _ownService.DeleteOwnAsync(id);
            return Ok();
        }
    }
}
