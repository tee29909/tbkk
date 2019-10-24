using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using tbkk.Models;

namespace tbkk.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        
        public Login Login { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string Username = Request.Form["Username"];
            string Password = Request.Form["Password"];
            Debug.WriteLine(Username);
            if (Username == string.Empty && Password == string.Empty)
            {
                return Page();

            }
            

            Login = await _context.Login
                .FirstOrDefaultAsync(m => string.Equals(m.Username, Username));

            if (Login == null)
            {
                return Page();
            }
            if (!Login.Password.Equals(Password))
            {
                return Page();
            }
            ViewData["Employee_EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeID");
            Debug.WriteLine(Login.Employee_EmployeeID);
            return RedirectToPage("./Home/Home");
        }
    }
}
