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
    public class OrganizationDatumsController : ControllerBase
    {
        private readonly db_a7d4d8_cybersportContext _context;

        public OrganizationDatumsController(db_a7d4d8_cybersportContext context)
        {
            _context = context;
        }

        // GET: api/OrganizationDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationDatum>>> GetOrganizationData()
        {
            return await _context.OrganizationData.ToListAsync();
        }

        // GET: api/OrganizationDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDatum>> GetOrganizationDatum(int id)
        {
            var organizationDatum = await _context.OrganizationData.FindAsync(id);

            if (organizationDatum == null)
            {
                return NotFound();
            }

            return organizationDatum;
        }

        // PUT: api/OrganizationDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationDatum(int id, OrganizationDatum organizationDatum)
        {
            if (id != organizationDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizationDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationDatumExists(id))
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

        // POST: api/OrganizationDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationDatum>> PostOrganizationDatum(OrganizationDatum organizationDatum)
        {
            _context.OrganizationData.Add(organizationDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationDatum", new { id = organizationDatum.Id }, organizationDatum);
        }

        // DELETE: api/OrganizationDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationDatum(int id)
        {
            var organizationDatum = await _context.OrganizationData.FindAsync(id);
            if (organizationDatum == null)
            {
                return NotFound();
            }

            _context.OrganizationData.Remove(organizationDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationDatumExists(int id)
        {
            return _context.OrganizationData.Any(e => e.Id == id);
        }
    }
}
