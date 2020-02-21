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
    public class addOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public addOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        

        [BindProperty]
        public DetailOT DetailOT { get; set; }
        [BindProperty]
        public OT OT { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public Employee Employee { get; set; }
        public IList<Employee>  Employeelist { get; set; }
        public IList<OTL> OTL { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            await OnLoad(); 
           
            

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        private async Task OnLoad()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            Employeelist = _context.Employee.Where(d => d.Employee_DepartmentID == Employee.Employee_DepartmentID).ToList();
            var DetailOTList = _context.DetailOT.Include(d => d.Employee)
                .Include(d => d.EmployeeAdd)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).Where(d => d.OT.date >= DateTime.Now && d.OT.date.Hour > 15 && d.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID).ToList();
            var OTs = _context.OT.Where(d => d.date >= DateTime.Now).ToList();

            foreach (var item in OTs)
            {
                var OTA = new OTL();
                OTA.OT = item;
                OTA.DetailOT = DetailOTList.Where(d => d.OT_OTID == item.OTID).ToList();
                OTL.Add(OTA);
            }


            ViewData["CarType_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "NameCar");
            ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "NameSet");
            ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "Name");
            
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                if (DetailOT.Employee_EmpID == 0)
                {
                    ModelState.AddModelError("DetailOT.Employee_EmpID", "The Employee field is required.");
                }
                if (DetailOT.Part_PaetID == 0)
                {
                    ModelState.AddModelError("DetailOT.Part_PaetID", "The Part field is required.");
                }
                if (DetailOT.FoodSet_FoodSetID == 0)
                {
                    ModelState.AddModelError("DetailOT.FoodSet_FoodSetID", "The Food Set field is required.");
                }
                await OnLoad();
                return Page();
            }
            var dateOT = _context.OT.FirstOrDefaultAsync(e => e.date == OT.date);
            if (dateOT.AsyncState==null)
            {

                OT.TimeStart = OT.date.Date + new TimeSpan(8,0,0);
                OT.TimeEnd = OT.date.Date + new TimeSpan(15, 0, 0);
                OT.TypeOT= OT.date.ToString("dddd");
                


            }
            else
            {
                OT = await dateOT;
            }
            //OT = await _context.OT.FirstOrDefaultAsync(e => e.OTID == DetailOT.OT_OTID);

            DateTime TimeS = OT.TimeStart;
            DetailOT.TimeStart = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, DetailOT.TimeStart.Hour, DetailOT.TimeStart.Minute, DetailOT.TimeStart.Second);
            DetailOT.TimeEnd = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, DetailOT.TimeEnd.Hour, DetailOT.TimeEnd.Minute, DetailOT.TimeEnd.Second);
            TimeSpan hour = DetailOT.TimeEnd - DetailOT.TimeStart;
            DetailOT.Hour = hour;

            
            int check = 0;
            check = checkTime(check);
            if (check == 1)
            {
                await OnLoad();
                return Page();
            }
            if (dateOT == null)
            { 
                _context.OT.Add(OT); 
            }
            


            DetailOT.OT_OTID = OT.OTID;

            _context.DetailOT.Add(DetailOT);
            await _context.SaveChangesAsync();
            





            return RedirectToPage("./../listOTs/listOT", new { id = DetailOT.Employee_EmpID });

        }

        private int checkTime(int check)
        {

            

            if (DetailOT.TimeStart == DetailOT.TimeEnd)
            {
                ModelState.AddModelError("timeError1", "The start time is less than the end time.");
                ModelState.AddModelError("timeError2", "The start time is less than the end time.");
                check = 1;

            }

            if (!DetailOT.Type.Equals("No") && getNamePart(DetailOT.Part_PaetID).Equals("No"))
            {
                check = 1;
                ModelState.AddModelError("partError", "Please select a route.");

            }


            if (!(OT.TypeOT.Equals("Sunday") || OT.TypeOT.Equals("Saturday")) && DetailOT.TimeStart.Hour < 17)
            {
                check = 1;
                ModelState.AddModelError("timeError1", "Time to start working overtime at 17.00 o'clock.");

            }


            if (!(OT.TypeOT.Equals("Sunday") || OT.TypeOT.Equals("Saturday")) && DetailOT.TimeEnd.Hour < 17)
            {
                check = 1;
                ModelState.AddModelError("timeError2", "Time to start working overtime at 17.00 o'clock.");

            }
            ////
            ///
            if ((OT.TypeOT.Equals("Sunday") || OT.TypeOT.Equals("Saturday")) && DetailOT.TimeStart.Hour < 8)
            {
                check = 1;
                ModelState.AddModelError("timeError1", "Time to start working overtime at 8.00 o'clock.");

            }

            if ((OT.TypeOT.Equals("Sunday") || OT.TypeOT.Equals("Saturday")) && DetailOT.TimeEnd.Hour < 8)
            {
                check = 1;
                ModelState.AddModelError("timeError2", "Time to start working overtime at 8.00 o'clock.");

            }


            if (OT.date < DateTime.Now)
            {
                check = 1;
                ModelState.AddModelError("OT.date", "Date is no less than the current.");

            }




            return check;
        }

        private string getNamePart(int ID)
        {
            string namePart="";
            var part = _context.Part.FirstOrDefault(u => u.PartID == ID);
                if (part.PartID == ID)
            {
                namePart = part.Name;
                
            }
            return namePart;
        }
    }

    public class OTL
    {
        public OT OT { get; set; }
        public List<DetailOT> DetailOT { get; set; }

    }
}
