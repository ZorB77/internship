﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class DistributionsController : ControllerBase
    {
        private DistributionService _distributionService;
        private LogWriter _logWriter;

        public DistributionsController(DistributionService distributionService, LogWriter logWriter)
        {
            _distributionService = distributionService;
            _logWriter = logWriter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribution>>> GetDistributions()
        {
            var distributions = await _distributionService.GetAllDistributionsAsync();
            _logWriter.Log("Get distributions.");
            return Ok(distributions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Distribution>> GetDistribution(int id)
        {
            var distribution = await _distributionService.GetDistributionAsync(id);

            if (distribution == null)
            {
                return NotFound();
            }

            _logWriter.Log($"Get distribution with id {id}.");
            return Ok(distribution);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribution(int id, Distribution distribution)
        {
            await _distributionService.UpdateDistributionAsync(id, distribution);
            _logWriter.Log($"Update distribution with id {id}.");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostDistribution(Distribution distribution)
        {
            _distributionService.AddDistributionAsync(distribution);
            _logWriter.Log("Add distribution.");
            return CreatedAtAction(nameof(GetDistribution), new { id = distribution.ID }, distribution);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribution(int id)
        {

            _distributionService.DeleteDistributionAsync(id);
            _logWriter.Log($"Delete distribution with id {id}.");
            return NoContent();
        }

    }
}
