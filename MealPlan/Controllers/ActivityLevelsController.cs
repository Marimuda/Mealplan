﻿using MealPlan.Data;
using MealPlan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlan.Controllers
{
    [Produces("application/json")]
    [Route("api/ActivityLevels")]
    public class ActivityLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityLevels
        [HttpGet]
        public IEnumerable<ActivityLevel> GetActivityLevel()
        {
            return _context.ActivityLevels;
        }

        // GET: api/ActivityLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityLevel = await _context.ActivityLevels.FirstOrDefaultAsync(m => m.BioId == id);

            if (activityLevel == null)
            {
                return NotFound();
            }

            return Ok(activityLevel);
        }

        // PUT: api/ActivityLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityLevel([FromRoute] int id, [FromBody] ActivityLevel activityLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityLevel.BioId)
            {
                return BadRequest();
            }

            _context.Entry(activityLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityLevels
        [HttpPost]
        public async Task<IActionResult> PostActivityLevel([FromBody] ActivityLevel activityLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ActivityLevels.Add(activityLevel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActivityLevelExists(activityLevel.BioId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivityLevel", new { id = activityLevel.BioId }, activityLevel);
        }

        // DELETE: api/ActivityLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityLevel = await _context.ActivityLevels.FirstOrDefaultAsync(m => m.BioId == id);
            if (activityLevel == null)
            {
                return NotFound();
            }

            _context.ActivityLevels.Remove(activityLevel);
            await _context.SaveChangesAsync();

            return Ok(activityLevel);
        }

        private bool ActivityLevelExists(int id)
        {
            return _context.ActivityLevels.Any(e => e.BioId == id);
        }
    }
}