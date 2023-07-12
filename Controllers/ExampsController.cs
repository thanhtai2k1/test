using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.Entities;

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampsController : ControllerBase
    {
        private readonly SM5Context _context;

        public ExampsController(SM5Context context)
        {
            _context = context;
        }

        // GET: api/Examps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examp>>> GetExamps()
        {
          if (_context.Examps == null)
          {
              return NotFound();
          }
            return await _context.Examps.ToListAsync();
        }

        // GET: api/Examps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Examp>> GetExamp(int id)
        {
          if (_context.Examps == null)
          {
              return NotFound();
          }
            var examp = await _context.Examps.FindAsync(id);

            if (examp == null)
            {
                return NotFound();
            }

            return examp;
        }

        // PUT: api/Examps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamp(int id, Examp examp)
        {
            if (id != examp.Examid)
            {
                return BadRequest();
            }

            _context.Entry(examp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExampExists(id))
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

        // POST: api/Examps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Examp>> PostExamp(Examp examp)
        {
          if (_context.Examps == null)
          {
              return Problem("Entity set 'SM5Context.Examps'  is null.");
          }
            _context.Examps.Add(examp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExampExists(examp.Examid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExamp", new { id = examp.Examid }, examp);
        }

        // DELETE: api/Examps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamp(int id)
        {
            if (_context.Examps == null)
            {
                return NotFound();
            }
            var examp = await _context.Examps.FindAsync(id);
            if (examp == null)
            {
                return NotFound();
            }

            _context.Examps.Remove(examp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExampExists(int id)
        {
            return (_context.Examps?.Any(e => e.Examid == id)).GetValueOrDefault();
        }
    }
}
