using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class LineTokenModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public LineTokenModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LineToken LineToken { get;set; }

        public Employee Employee { get; set; }
        public int Debug { get; set; }
        
        public async Task OnGetAsync()
        {
            Debug = 0;
            await Onlode();
        }

        private async Task Onlode()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            LineToken = await _context.LineToken
                .Include(l => l.Company).FirstOrDefaultAsync(e => e.Company_CompanyID == Employee.Company_CompanyID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Debug = 1;
                await Onlode();
                return Page();
            }

            _context.LineToken.Add(LineToken);
            await _context.SaveChangesAsync();

            await Onlode();
           

            return RedirectToPage("./LineToken");
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                Debug = 2;
                await Onlode();
                return Page();
            }

            _context.Attach(LineToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineTokenExists(LineToken.LineTokenID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            await Onlode();
            return RedirectToPage("./LineToken");
        }

        private bool LineTokenExists(int id)
        {
            return _context.LineToken.Any(e => e.LineTokenID == id);
        }
    }
}
