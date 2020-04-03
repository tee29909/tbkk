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


        public IList<LineToken> LineToken { get;set; }

        public Employee Employee { get; set; }

        public async Task OnGetAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            LineToken = await _context.LineToken
                .Include(l => l.Company).Where(e => e.Company_CompanyID == Employee.Employee_CompanyID).ToListAsync();
        }
    }
}
