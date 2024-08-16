using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;

namespace MovieApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionsController : ControllerBase
    {
        private DistributionService _distributionService;

        public DistributionsController(DistributionService distributionService)
        {
            _distributionService = distributionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distribution>>> GetDistributions()
        {
            var distributions = await _distributionService.GetAllDistributionsAsync();
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

            return Ok(distribution);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribution(int id, Distribution distribution)
        {
            await _distributionService.UpdateDistributionAsync(id, distribution);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostDistribution(Distribution distribution)
        {
            _distributionService.AddDistributionAsync(distribution);
            return CreatedAtAction(nameof(GetDistribution), new { id = distribution.ID }, distribution);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribution(int id)
        {

            _distributionService.DeleteDistributionAsync(id);
            return NoContent();
        }

    }
}
