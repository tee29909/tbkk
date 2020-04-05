﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Controllers.getPoint
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly tbkkdbContext _context;

        public PointsController(tbkkdbContext context)
        {
            _context = context;
        }

        // GET: api/Points
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoint()
        {
            return await _context.Point.ToListAsync();
        }

        // GET: api/Points/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(int id)
        {
            var point = await _context.Point.FindAsync(id);

            if (point == null)
            {
                return NotFound();
            }

            return point;
        }

        // PUT: api/Points/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoint(int id, Point point)
        {
            if (id != point.PointID)
            {
                return BadRequest();
            }

            _context.Entry(point).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(id))
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

        // POST: api/Points
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(Point point)
        {
            _context.Point.Add(point);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoint", new { id = point.PointID }, point);
        }

        // DELETE: api/Points/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Point>> DeletePoint(int id)
        {
            var point = await _context.Point.FindAsync(id);
            if (point == null)
            {
                return NotFound();
            }

            _context.Point.Remove(point);
            await _context.SaveChangesAsync();

            return point;
        }

        private bool PointExists(int id)
        {
            return _context.Point.Any(e => e.PointID == id);
        }
    }
}
