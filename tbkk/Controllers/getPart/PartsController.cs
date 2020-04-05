using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controllers.getPart
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public PartsController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetPart()
        {
            return await _context.Part.ToListAsync();
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(int id)
        {
            var part = await _context.Part.FindAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(int id, Part part)
        {
            if (id != part.PartID)
            {
                return BadRequest();
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST: api/Parts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Part>> PostPart(Part part)
        {
            _context.Part.Add(part);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPart", new { id = part.PartID }, part);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Part>> DeletePart(int id)
        {
            var part = await _context.Part.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Part.Remove(part);
            await _context.SaveChangesAsync();

            return part;
        }

        private bool PartExists(int id)
        {
            return _context.Part.Any(e => e.PartID == id);
        }
    }
}
