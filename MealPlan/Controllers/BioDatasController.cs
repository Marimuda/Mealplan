using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Controllers
{
    [Produces("application/json")]
    [Route("api/BioDatas")]
    public class BioDatasController : Controller
    {
        private readonly MealplanContext _context;

        public BioDatasController(MealplanContext context)
        {
            _context = context;
        }

        // GET: api/BioDatas
        [HttpGet]
        public IEnumerable<BioData> GetBioData()
        {
            return _context.BioData;
        }

        // GET: api/BioDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBioData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bioData = await _context.BioData.FirstOrDefaultAsync(m => m.BioId == id);

            if (bioData == null)
            {
                return NotFound();
            }

            return Ok(bioData);
        }

        // PUT: api/BioDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBioData([FromRoute] int id, [FromBody] BioData bioData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bioData.BioId)
            {
                return BadRequest();
            }

            _context.Entry(bioData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BioDataExists(id))
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

        // POST: api/BioDatas
        [HttpPost]
        public async Task<IActionResult> PostBioData([FromBody] BioData bioData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BioData.Add(bioData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBioData", new { id = bioData.BioId }, bioData);
        }

        // DELETE: api/BioDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBioData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bioData = await _context.BioData.FirstOrDefaultAsync(m => m.BioId == id);
            if (bioData == null)
            {
                return NotFound();
            }

            _context.BioData.Remove(bioData);
            await _context.SaveChangesAsync();

            return Ok(bioData);
        }

        private bool BioDataExists(int id)
        {
            return _context.BioData.Any(e => e.BioId == id);
        }
    }
}