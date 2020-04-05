using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class PointModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public PointModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<Point>  PointList { get; set; }
        public Employee Employee { get; set; }
        public Part Part { get; set; }
        public int Debug { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Debug = 0;
            await OnLode(id);

            return Page();
        }

        private async Task OnLode(int id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            PointList = await _context.Point
               .Include(p => p.Part).Where(e => e.Point_PartID == id).ToListAsync();
            Part = await _context.Part
              .FirstOrDefaultAsync(e => e.PartID == id);
        }

        [BindProperty]
        public Point Point { get; set; }
        [BindProperty]
        public Point PointEdit { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            Debug = 0;
            var check = 0;
            if (Point.NamePoint == null)
            {
                check = 1;
                ModelState.AddModelError("Point.NamePoint", "The NamePoint field is required.");
            }

            if (check == 1)
            {
                Debug = 1;
                await OnLode(Point.Point_PartID);
                return Page();
            }

            _context.Point.Add(Point);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Point", new { id = Point.Point_PartID });
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            Debug = 0;
            var check = 0;
            if (PointEdit.NamePoint == null)
            {
                check = 1;
                ModelState.AddModelError("PointEdit.NamePoint", "The NamePoint field is required.");
            }

            if (check == 1)
            {
                Debug = 2;
                await OnLode(PointEdit.Point_PartID);
                return Page();
            }

            _context.Attach(PointEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(PointEdit.PointID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Point", new { id = PointEdit.Point_PartID });
        }

        private bool PointExists(int id)
        {
            return _context.Point.Any(e => e.PointID == id);
        }
    }
}
