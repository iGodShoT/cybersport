using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CybersportAPI.Models;

namespace CybersportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatiesController : ControllerBase
    {
        private readonly db_a7d4d8_cybersportContext _context;

        public TreatiesController(db_a7d4d8_cybersportContext context)
        {
            _context = context;
        }

        // GET: api/Treaties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treaty>>> GetTreaties()
        {
            return await _context.Treaties.ToListAsync();
        }

        // GET: api/Treaties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Treaty>> GetTreaty(int id)
        {
            var treaty = await _context.Treaties.FindAsync(id);

            if (treaty == null)
            {
                return NotFound();
            }

            return treaty;
        }

        // PUT: api/Treaties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreaty(int id, Treaty treaty)
        {
            if (id != treaty.Id)
            {
                return BadRequest();
            }

            _context.Entry(treaty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatyExists(id))
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

        // POST: api/Treaties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Treaty>> PostTreaty(Treaty treaty)
        {
            _context.Treaties.Add(treaty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreaty", new { id = treaty.Id }, treaty);
        }

        // DELETE: api/Treaties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreaty(int id)
        {
            var treaty = await _context.Treaties.FindAsync(id);
            if (treaty == null)
            {
                return NotFound();
            }

            _context.Treaties.Remove(treaty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreatyExists(int id)
        {
            return _context.Treaties.Any(e => e.Id == id);
        }
    }
}
