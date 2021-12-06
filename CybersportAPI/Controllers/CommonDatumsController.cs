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
    public class CommonDatumsController : ControllerBase
    {
        private readonly db_a7d4d8_cybersportContext _context;

        public CommonDatumsController(db_a7d4d8_cybersportContext context)
        {
            _context = context;
        }

        // GET: api/CommonDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonDatum>>> GetCommonData()
        {
            return await _context.CommonData.ToListAsync();
        }

        // GET: api/CommonDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonDatum>> GetCommonDatum(int id)
        {
            var commonDatum = await _context.CommonData.FindAsync(id);

            if (commonDatum == null)
            {
                return NotFound();
            }

            return commonDatum;
        }

        // PUT: api/CommonDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommonDatum(int id, CommonDatum commonDatum)
        {
            if (id != commonDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(commonDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommonDatumExists(id))
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

        // POST: api/CommonDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommonDatum>> PostCommonDatum(CommonDatum commonDatum)
        {
            _context.CommonData.Add(commonDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommonDatum", new { id = commonDatum.Id }, commonDatum);
        }

        // DELETE: api/CommonDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommonDatum(int id)
        {
            var commonDatum = await _context.CommonData.FindAsync(id);
            if (commonDatum == null)
            {
                return NotFound();
            }

            _context.CommonData.Remove(commonDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommonDatumExists(int id)
        {
            return _context.CommonData.Any(e => e.Id == id);
        }
    }
}
