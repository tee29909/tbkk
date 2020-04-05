using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controllers.FoodSetCon
{
    [Route("api/[controller]")]
    [ApiController]
    public class getFoodSetsController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public getFoodSetsController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/getFoodSets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodSet>>> GetFoodSet()
        {
            return await _context.FoodSet.ToListAsync();
        }

        // GET: api/getFoodSets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodSet>> GetFoodSet(int id)
        {
            var foodSet = await _context.FoodSet.FindAsync(id);

            if (foodSet == null)
            {
                return NotFound();
            }

            return foodSet;
        }

        // PUT: api/getFoodSets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodSet(int id, FoodSet foodSet)
        {
            if (id != foodSet.FoodSetID)
            {
                return BadRequest();
            }

            _context.Entry(foodSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSetExists(id))
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

        // POST: api/getFoodSets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FoodSet>> PostFoodSet(FoodSet foodSet)
        {
            _context.FoodSet.Add(foodSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodSet", new { id = foodSet.FoodSetID }, foodSet);
        }

        // DELETE: api/getFoodSets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodSet>> DeleteFoodSet(int id)
        {
            var foodSet = await _context.FoodSet.FindAsync(id);
            if (foodSet == null)
            {
                return NotFound();
            }

            _context.FoodSet.Remove(foodSet);
            await _context.SaveChangesAsync();

            return foodSet;
        }

        private bool FoodSetExists(int id)
        {
            return _context.FoodSet.Any(e => e.FoodSetID == id);
        }
    }
}
