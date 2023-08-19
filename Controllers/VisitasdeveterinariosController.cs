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
    public class VisitasdeveterinariosController : ControllerBase
    {
        private readonly SavemeContext _context;

        public VisitasdeveterinariosController(SavemeContext context)
        {
            _context = context;
        }

        // GET: api/Visitasdeveterinarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitasveterinario>>> GetVisitasveterinarios()
        {
          if (_context.Visitasveterinarios == null)
          {
              return NotFound();
          }
            return await _context.Visitasveterinarios.ToListAsync();
        }

        // GET: api/Visitasdeveterinarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitasveterinario>> GetVisitasveterinario(int id)
        {
          if (_context.Visitasveterinarios == null)
          {
              return NotFound();
          }
            var visitasveterinario = await _context.Visitasveterinarios.FindAsync(id);

            if (visitasveterinario == null)
            {
                return NotFound();
            }

            return visitasveterinario;
        }

        // PUT: api/Visitasdeveterinarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitasveterinario(int id, Visitasveterinario visitasveterinario)
        {
            if (id != visitasveterinario.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitasveterinario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitasveterinarioExists(id))
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

        // POST: api/Visitasdeveterinarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitasveterinario>> PostVisitasveterinario(Visitasveterinario visitasveterinario)
        {
          if (_context.Visitasveterinarios == null)
          {
              return Problem("Entity set 'SavemeContext.Visitasveterinarios'  is null.");
          }
            _context.Visitasveterinarios.Add(visitasveterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitasveterinario", new { id = visitasveterinario.Id }, visitasveterinario);
        }

        // DELETE: api/Visitasdeveterinarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitasveterinario(int id)
        {
            if (_context.Visitasveterinarios == null)
            {
                return NotFound();
            }
            var visitasveterinario = await _context.Visitasveterinarios.FindAsync(id);
            if (visitasveterinario == null)
            {
                return NotFound();
            }

            _context.Visitasveterinarios.Remove(visitasveterinario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitasveterinarioExists(int id)
        {
            return (_context.Visitasveterinarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
