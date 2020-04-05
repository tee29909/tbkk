using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controllers.getCompanyCar
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCarsController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public CompanyCarsController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyCar>>> GetCompanyCar()
        {
            return await _context.CompanyCar.ToListAsync();
        }

        // GET: api/CompanyCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyCar>> GetCompanyCar(int id)
        {
            var companyCar = await _context.CompanyCar.FindAsync(id);

            if (companyCar == null)
            {
                return NotFound();
            }

            return companyCar;
        }

        // PUT: api/CompanyCars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyCar(int id, CompanyCar companyCar)
        {
            if (id != companyCar.CompanyCarID)
            {
                return BadRequest();
            }

            _context.Entry(companyCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyCarExists(id))
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

        // POST: api/CompanyCars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CompanyCar>> PostCompanyCar(CompanyCar companyCar)
        {
            _context.CompanyCar.Add(companyCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyCar", new { id = companyCar.CompanyCarID }, companyCar);
        }

        // DELETE: api/CompanyCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyCar>> DeleteCompanyCar(int id)
        {
            var companyCar = await _context.CompanyCar.FindAsync(id);
            if (companyCar == null)
            {
                return NotFound();
            }

            _context.CompanyCar.Remove(companyCar);
            await _context.SaveChangesAsync();

            return companyCar;
        }

        private bool CompanyCarExists(int id)
        {
            return _context.CompanyCar.Any(e => e.CompanyCarID == id);
        }
    }
}
