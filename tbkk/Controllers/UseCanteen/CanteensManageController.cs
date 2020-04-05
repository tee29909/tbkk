using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controllers.UseCanteen
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanteensManageController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public CanteensManageController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/CanteensManage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canteen>>> GetCanteen()
        {
            return await _context.Canteen.ToListAsync();
        }

        // GET: api/CanteensManage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canteen>> GetCanteen(int id)
        {
            var canteen = await _context.Canteen.FindAsync(id);

            if (canteen == null)
            {
                return NotFound();
            }

            return canteen;
        }

        // PUT: api/CanteensManage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanteen(int id, Canteen canteen)
        {
            if (id != canteen.CanteenID)
            {
                return BadRequest();
            }

            _context.Entry(canteen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(id))
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

        // POST: api/CanteensManage
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Canteen>> PostCanteen(Canteen canteen)
        {
            _context.Canteen.Add(canteen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanteen", new { id = canteen.CanteenID }, canteen);
        }

        // DELETE: api/CanteensManage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canteen>> DeleteCanteen(int id)
        {
            var canteen = await _context.Canteen.FindAsync(id);
            if (canteen == null)
            {
                return NotFound();
            }

            _context.Canteen.Remove(canteen);
            await _context.SaveChangesAsync();

            return canteen;
        }

        private bool CanteenExists(int id)
        {
            return _context.Canteen.Any(e => e.CanteenID == id);
        }
    }
}
