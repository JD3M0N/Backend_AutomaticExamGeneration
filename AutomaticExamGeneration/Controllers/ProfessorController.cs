﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorDto professorDto)
        {
            if (professorDto.U_ID <= 0)
            {
                return BadRequest("Invalid professor ID.");
            }

            var professor = new Professor
            {
                Id = professorDto.U_ID,
                Speciality = professorDto.Speciality
            };

            await _professorService.AddProfessorAsync(professor);
            return Ok(professor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAllProfessors()
        {
            var professors = await _professorService.GetProfessorsAsync();
            return Ok(professors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, [FromBody] ProfessorDto professorDto)
        {
            var professor = new Professor
            {
                Id = id,
                Speciality = professorDto.Speciality
            };

            await _professorService.UpdateProfessorAsync(professor);
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            await _professorService.DeleteProfessorAsync(id);
            return Ok();
        }
    }
}
