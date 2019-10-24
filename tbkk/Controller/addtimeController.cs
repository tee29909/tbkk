using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tbkk.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tbkk.Controller
{
    [Route("api/[controller]")]
    public class addtimeController : ControllerBase
    {

        private readonly tbkk.Models.tbkkdbContext _context;

        public addtimeController(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        
        public async Task<IActionResult> Postaddtime([FromBody] OT OT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.OT.Add(OT);
            DateTime date = DateTime.Now;
            date.AddHours(8);
            date.AddMinutes(0);
           
            OT.TimeStart = date;
            date.AddHours(15);
            date.AddMinutes(0);
            OT.TimeEnd = date;
            OT.TypeOT = "Nomal";
            OT.TypStatus = "Open";

            await _context.SaveChangesAsync();

            //return Page();
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
