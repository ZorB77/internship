﻿using Microsoft.AspNetCore.Mvc;
using Movies.Services;
using System.Collections.Generic;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociationController : ControllerBase
    {
        private readonly IAssociationService _associationService;

        public AssociationController(IAssociationService associationService)
        {
            _associationService = associationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieStudioAssociation>> GetAllAssociations()
        {
            var associations = _associationService.GetAllAssociations();
            return Ok(associations);
        }

        [HttpPost]
        public IActionResult AddAssociation(int id, int movieId, int studioId)
        {
            try
            {
                _associationService.AddAssociation(id, movieId, studioId);
                return CreatedAtAction(nameof(GetAllAssociations), new { id }, new { id, movieId, studioId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
