using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tbkk.Controller
{
    public class loginController : ControllerBase
    {

       
        public IActionResult Index()
        {

            
           
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
    }
}