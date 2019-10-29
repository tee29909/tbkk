using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTsController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public OTsController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/OTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OT>>> GetOT()
        {
            return await _context.OT.ToListAsync();
        }

        // GET: api/OTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OT>> GetOT(int id)
        {
            var oT = await _context.OT.FindAsync(id);

            if (oT == null)
            {
                return NotFound();
            }

            return oT;
        }

        // PUT: api/OTs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOT(int id, OT oT)
        {
            if (id != oT.OTID)
            {
                return BadRequest();
            }

            _context.Entry(oT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OTExists(id))
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

        // POST: api/OTs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OT>> PostOT(OT oT)
        {
            _context.OT.Add(oT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOT", new { id = oT.OTID }, oT);
        }

        // DELETE: api/OTs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OT>> DeleteOT(int id)
        {
            var oT = await _context.OT.FindAsync(id);
            if (oT == null)
            {
                return NotFound();
            }

            _context.OT.Remove(oT);
            await _context.SaveChangesAsync();

            return oT;
        }

        private bool OTExists(int id)
        {
            return _context.OT.Any(e => e.OTID == id);
        }
    }
}
