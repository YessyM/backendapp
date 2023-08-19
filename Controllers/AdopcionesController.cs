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
    public class AdopcionesController : ControllerBase
    {
        private readonly SavemeContext _context;

        public AdopcionesController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Adopciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adopcion>>> GetAdopcions()
        {
          if (_context.Adopcions == null)
          {
              return NotFound();
          }
            return await _context.Adopcions.ToListAsync();
        }

        // GET: api/Adopciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adopcion>> GetAdopcion(int id)
        {
          if (_context.Adopcions == null)
          {
              return NotFound();
          }
            var adopcion = await _context.Adopcions.FindAsync(id);

            if (adopcion == null)
            {
                return NotFound();
            }

            return adopcion;
        }

        // PUT: api/Adopciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdopcion(int id, Adopcion adopcion)
        {
            if (id != adopcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(adopcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionExists(id))
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

        // POST: api/Adopciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adopcion>> PostAdopcion(Adopcion adopcion)
        {
          if (_context.Adopcions == null)
          {
              return Problem("Entity set 'SavemeContext.Adopcions'  is null.");
          }
            _context.Adopcions.Add(adopcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdopcion", new { id = adopcion.Id }, adopcion);
        }

        // DELETE: api/Adopciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdopcion(int id)
        {
            if (_context.Adopcions == null)
            {
                return NotFound();
            }
            var adopcion = await _context.Adopcions.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            _context.Adopcions.Remove(adopcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdopcionExists(int id)
        {
            return (_context.Adopcions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
