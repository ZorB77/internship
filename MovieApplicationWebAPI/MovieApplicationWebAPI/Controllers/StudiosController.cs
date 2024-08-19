﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using MovieApplicationWebAPI.Utilities;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private StudioService _studioService;
        private LogWriter _logWriter;

        public StudiosController(StudioService studioService, LogWriter logWriter)
        {
            _studioService = studioService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            var studios = await _studioService.GetAllStudiosAsync();
            _logWriter.Log($"Get studios.");
            return Ok(studios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            var studio = await _studioService.GetStudioAsync(id);

            if (studio == null)
            {
                return NotFound();
            }
            _logWriter.Log($"Get studio with id {id}.");
            return Ok(studio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudio(int id, Studio studio)
        {
            await _studioService.UpdateStudioAsync(id, studio);
            _logWriter.Log($"Update studio with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostStudio(Studio studio)
        {
            _studioService.AddStudioAsync(studio);
            _logWriter.Log($"Add studio: {studio.Name}.");
            return CreatedAtAction(nameof(GetStudio), new { id = studio.ID }, studio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudio(int id)
        {

            _studioService.DeleteStudioAsync(id);
            _logWriter.Log($"Delete studio with id {id}.");
            return NoContent();
        }
    }
}
