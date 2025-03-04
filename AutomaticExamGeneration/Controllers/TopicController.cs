﻿using Application.Interfaces;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic([FromBody] CreateTopicDto createTopicDto)
        {
            if (createTopicDto == null || string.IsNullOrEmpty(createTopicDto.Name) || createTopicDto.AssignmentId <= 0)
            {
                return BadRequest("Invalid data. Both Topic Name and AssignmentId are required.");
            }

            await _topicService.AddTopicAsync(createTopicDto.Name, createTopicDto.AssignmentId);

            // Write in console that a topic has been added
            System.Console.WriteLine($"Topic '{createTopicDto.Name}' added to Assignment ID {createTopicDto.AssignmentId}");
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAllTopics()
        {
            // Write in console that all topics have been retrieved
            System.Console.WriteLine("All topics retrieved");
            var topics = await _topicService.GetAllTopicsAsync();
            return Ok(topics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound($"No topic found with ID {id}.");
            }

            // Write to the console the topic's name
            System.Console.WriteLine($"Topic: {topic.Name} found");

            return Ok(topic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            // Write in console that a topic has been deleted
            System.Console.WriteLine($"Topic ID {id} deleted");
            await _topicService.DeleteTopicAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] TopicDto topicDto)
        {
            if (topicDto == null || string.IsNullOrEmpty(topicDto.Name) || topicDto.AssignmentId <= 0)
            {
                return BadRequest("Invalid data. Both Topic Name and AssignmentId are required.");
            }

            await _topicService.UpdateTopicAsync(id, topicDto.Name, topicDto.AssignmentId);
            return Ok();
        }
    }
}
