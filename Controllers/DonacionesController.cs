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
    public class DonacionesController : ControllerBase
    {
        private readonly SavemeContext _context;

        public DonacionesController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Donaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donacion>>> GetDonacions()
        {
          if (_context.Donacions == null)
          {
              return NotFound();
          }
            return await _context.Donacions.ToListAsync();
        }

        // GET: api/Donaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> GetDonacion(int id)
        {
          if (_context.Donacions == null)
          {
              return NotFound();
          }
            var donacion = await _context.Donacions.FindAsync(id);

            if (donacion == null)
            {
                return NotFound();
            }

            return donacion;
        }

        // PUT: api/Donaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacion(int id, Donacion donacion)
        {
            if (id != donacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(donacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // POST: api/Donaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donacion>> PostDonacion(Donacion donacion)
        {
          if (_context.Donacions == null)
          {
              return Problem("Entity set 'SavemeContext.Donacions'  is null.");
          }
            _context.Donacions.Add(donacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacion", new { id = donacion.Id }, donacion);
        }

        // DELETE: api/Donaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacion(int id)
        {
            if (_context.Donacions == null)
            {
                return NotFound();
            }
            var donacion = await _context.Donacions.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            _context.Donacions.Remove(donacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionExists(int id)
        {
            return (_context.Donacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
