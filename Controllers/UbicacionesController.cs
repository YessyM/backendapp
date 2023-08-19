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
    public class UbicacionesController : ControllerBase
    {
        private readonly SavemeContext _context;

        public UbicacionesController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacions()
        {
          if (_context.Ubicacions == null)
          {
              return NotFound();
          }
            return await _context.Ubicacions.ToListAsync();
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
          if (_context.Ubicacions == null)
          {
              return NotFound();
          }
            var ubicacion = await _context.Ubicacions.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return ubicacion;
        }

        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
          if (_context.Ubicacions == null)
          {
              return Problem("Entity set 'SavemeContext.Ubicacions'  is null.");
          }
            _context.Ubicacions.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacion", new { id = ubicacion.Id }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            if (_context.Ubicacions == null)
            {
                return NotFound();
            }
            var ubicacion = await _context.Ubicacions.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicacions.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacionExists(int id)
        {
            return (_context.Ubicacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
