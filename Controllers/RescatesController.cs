using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using savemeapi.Data;
using savemeapi.Models;

namespace savemeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RescatesController : ControllerBase
    {
        private readonly SavemeContext _context;

        public RescatesController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Rescates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rescate>>> GetRescates()
        {
          if (_context.Rescates == null)
          {
              return NotFound();
          }
            return await _context.Rescates.ToListAsync();
        }

        // GET: api/Rescates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rescate>> GetRescate(int id)
        {
          if (_context.Rescates == null)
          {
              return NotFound();
          }
            var rescate = await _context.Rescates.FindAsync(id);

            if (rescate == null)
            {
                return NotFound();
            }

            return rescate;
        }

        // PUT: api/Rescates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRescate(int id, Rescate rescate)
        {
            if (id != rescate.Idrescate)
            {
                return BadRequest();
            }

            _context.Entry(rescate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RescateExists(id))
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

        // POST: api/Rescates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rescate>> PostRescate(Rescate rescate)
        {
          if (_context.Rescates == null)
          {
              return Problem("Entity set 'SavemeContext.Rescates'  is null.");
          }
            _context.Rescates.Add(rescate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RescateExists(rescate.Idrescate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRescate", new { id = rescate.Idrescate }, rescate);
        }

        // DELETE: api/Rescates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRescate(int id)
        {
            if (_context.Rescates == null)
            {
                return NotFound();
            }
            var rescate = await _context.Rescates.FindAsync(id);
            if (rescate == null)
            {
                return NotFound();
            }

            _context.Rescates.Remove(rescate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RescateExists(int id)
        {
            return (_context.Rescates?.Any(e => e.Idrescate == id)).GetValueOrDefault();
        }
    }
}
