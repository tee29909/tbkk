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
using Microsoft.AspNetCore.Http;

namespace tbkk.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Login Login { get; set; }
        public void OnGet()
        {
            HttpContext.Session.SetLogin(0);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //string Username = Request.Form["Username"];
            //string Password = Request.Form["Password"];
            

            
            if (Login.Username == string.Empty)
            {
                ModelState.AddModelError("user", "The username is incorrect.");
                return Page();
            }
            if (Login.Password == string.Empty)
            {
                ModelState.AddModelError("pass", "The Password is incorrect.");
                return Page();
            }
            var checkLogin = false;
            try
            {
                checkLogin = await _context.Login.Include(e => e.Employee)
              .AnyAsync(u => u.Username.Equals(Login.Username) && u.Username.Equals(Login.Password));
            }
            catch (Exception)
            {
                checkLogin = false;
            }
          

            if (checkLogin == false)
            {
                
                ModelState.AddModelError("error", "The username or password is incorrect.");
                return Page();
            }



            //ViewData["Login_EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeID");


            Login = await _context.Login.FirstOrDefaultAsync(u => u.Username.Equals(Login.Username) && u.Username.Equals(Login.Password));
            HttpContext.Session.SetLogin(Login.Login_EmployeeID);
            return RedirectToPage("./Home/Home");



        }

    }
}
