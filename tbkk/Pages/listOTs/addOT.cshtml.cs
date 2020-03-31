using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

using System.Globalization;

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
        public DetailOT EditDetailOT { get; set; }


        [BindProperty]
        public OT OT { get; set; }

        
        public OT OTset { get; set; }

        

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.


        public Employee Employee { get; set; }
        public IList<Employee>  Employeelist { get; set; }




        




        
        public IList<OTL> OTL { get; set; }

        public int Defal { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            
            ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "NameSet");
            ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "Name");

            try
            {
                await OnLoad();
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }
            

            


            Defal = 0;
            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        private async Task OnLoad()
        {
            ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "NameSet");
            ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "Name");

           
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            Employeelist = await _context.Employee.Where(d => d.Employee_DepartmentID == Employee.Employee_DepartmentID && d.Employee_CompanyID == Employee.Employee_CompanyID).ToListAsync();
            


            var GetDate = DateTime.Now;
            var date = new DateTime(GetDate.Year, GetDate.Month, GetDate.Day);
            var DetailOTList = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).Where(d => d.OT.date >= date).ToListAsync();
            var OTlists = await _context.OT.Where(d => d.date >= date && d.OT_CompanyID == Employee.Employee_CompanyID).ToListAsync();

            var OTLadd = new List<OTL>();
            foreach (var item in OTlists)
            {
                var OTA = new OTL();
                OTA.OT = item;
                OTA.DetailOT = new List<DetailOT>();
                var detailAdd = DetailOTList.Where(d => d.OT_OTID == item.OTID && d.Employee.Employee_DepartmentID ==Employee.Employee_DepartmentID).ToList();
                if (detailAdd.Count != 0)
                {
                    OTA.DetailOT = detailAdd;
                }
                OTLadd.Add(OTA);


            }
            OTL = OTLadd;

           


        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            
            if (!ModelState.IsValid)
            {
                if (EditDetailOT.Employee_EmpID == 0)
                {
                    ModelState.AddModelError("EditDetailOT.Employee_EmpID", "The Employee field is required.");
                }
                if (EditDetailOT.Part_PaetID == 0)
                {
                    ModelState.AddModelError("EditDetailOT.Part_PaetID", "The Part field is required.");
                }
                if (EditDetailOT.FoodSet_FoodSetID == 0)
                {
                    ModelState.AddModelError("EditDetailOT.FoodSet_FoodSetID", "The Food Set field is required.");
                }
                if (EditDetailOT.Type == null)
                {
                    ModelState.AddModelError("EditDetailOT.Type", "The Travel Type field is required.");
                }

                try
                {
                    await OnLoad();
                }
                catch (Exception)
                {
                    return RedirectToPage("./index");
                }
                Defal = 2;
                return Page();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);

            var OTcheck = await _context.OT.FirstOrDefaultAsync(e => e.OTID == EditDetailOT.OT_OTID);

            DateTime TimeS = OTcheck.date;
            EditDetailOT.TimeStart = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, EditDetailOT.TimeStart.Hour, EditDetailOT.TimeStart.Minute, EditDetailOT.TimeStart.Second);
            EditDetailOT.TimeEnd = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, EditDetailOT.TimeEnd.Hour, EditDetailOT.TimeEnd.Minute, EditDetailOT.TimeEnd.Second);
            TimeSpan hour = EditDetailOT.TimeEnd - EditDetailOT.TimeStart;
            EditDetailOT.Hour = hour;


            int check = 0;
            check = await CheckTimeEditAsync(OTcheck);

            if (check == 1)
            {
                Defal = 2;
                try
                {
                    await OnLoad();
                }
                catch (Exception)
                {
                    return RedirectToPage("./index");
                }
                return Page();
            }

             Defal = 0;


            _context.Attach(EditDetailOT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOTExists(EditDetailOT.DetailOTID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./../listOTs/addOT");

        }

        private bool DetailOTExists(int id)
        {
            return _context.DetailOT.Any(e => e.DetailOTID == id);
        }

        private async Task<int> CheckTimeEditAsync(OT OTcheck)
        {
            var check = 0;
            if (EditDetailOT.TimeStart == EditDetailOT.TimeEnd)
            {
                ModelState.AddModelError("EditDetailOT.TimeStart", "The start time is less than the end time.");
                ModelState.AddModelError("EditDetailOT.TimeEnd", "The start time is less than the end time.");
                check = 1;

            } 
            if (!EditDetailOT.Type.Equals("No"))
            {
                var partName = await getNamePartAsync(EditDetailOT.Part_PaetID);
                if (partName.Equals("No"))
                {
                    check = 1;
                ModelState.AddModelError("EditDetailOT.Part_PaetID", "Please select a route.");

                }
                

            }

           

            if (!(OTcheck.TypeOT.Equals("Sunday") || OTcheck.TypeOT.Equals("Saturday")) && EditDetailOT.TimeStart.Hour < 17)
            {
                check = 1;
                ModelState.AddModelError("EditDetailOT.TimeStart", "Time to start working overtime at 17.00 o'clock.");

            }


            if (!(OTcheck.TypeOT.Equals("Sunday") || OTcheck.TypeOT.Equals("Saturday")) && EditDetailOT.TimeEnd.Hour < 17)
            {
                check = 1;
                ModelState.AddModelError("EditDetailOT.TimeEnd", "Time to start working overtime at 17.00 o'clock.");

            }
            ////
            ///
            if ((OTcheck.TypeOT.Equals("Sunday") || OTcheck.TypeOT.Equals("Saturday")) && EditDetailOT.TimeStart.Hour < 8)
            {
                check = 1;
                ModelState.AddModelError("EditDetailOT.TimeStart", "Time to start working overtime at 8.00 o'clock.");

            }

            if ((OTcheck.TypeOT.Equals("Sunday") || OTcheck.TypeOT.Equals("Saturday")) && EditDetailOT.TimeEnd.Hour < 8)
            {
                check = 1;
                ModelState.AddModelError("EditDetailOT.TimeEnd", "Time to start working overtime at 8.00 o'clock.");

            }

            return check;
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
                if (DetailOT.Type == null)
                {
                    ModelState.AddModelError("DetailOT.Type", "The Travel Type field is required.");
                }
                try
                {
                    await OnLoad();
                }
                catch (Exception)
                {
                    return RedirectToPage("./index");
                }

                Defal = 1;
                return Page();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            var dateOT = _context.OT.Any(e => e.date == OT.date && e.OT_CompanyID == Employee.Employee_CompanyID);
            if (dateOT==false)
            {

                OT.TimeStart = OT.date.Date + new TimeSpan(8,0,0);
                OT.TimeEnd = OT.date.Date + new TimeSpan(15, 0, 0);
                OT.TypeOT= OT.date.ToString("dddd", CultureInfo.InvariantCulture);
                OT.TypStatus = "Open";
            }
            else
            {
                OT = await _context.OT.FirstOrDefaultAsync(e => e.date == OT.date && e.OT_CompanyID == Employee.Employee_CompanyID);
            }
            //OT = await _context.OT.FirstOrDefaultAsync(e => e.OTID == DetailOT.OT_OTID);

            DateTime TimeS = OT.TimeStart;
            DetailOT.TimeStart = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, DetailOT.TimeStart.Hour, DetailOT.TimeStart.Minute, DetailOT.TimeStart.Second);
            DetailOT.TimeEnd = new DateTime(TimeS.Year, TimeS.Month, TimeS.Day, DetailOT.TimeEnd.Hour, DetailOT.TimeEnd.Minute, DetailOT.TimeEnd.Second);
            TimeSpan hour = DetailOT.TimeEnd - DetailOT.TimeStart;
            DetailOT.Hour = hour;

            
            int check = 0;
            check = await checkTimeAsync(check);
            if (check == 1)
            {
                Defal = 1;
                try
                {
                    await OnLoad();
                }
                catch (Exception)
                {
                    return RedirectToPage("./index");
                }
                return Page();
            }
            if (dateOT == false)
            {
                await addnewOT();
            }
            else
            {
                DetailOT.OT_OTID = OT.OTID;
            }

            var checkOT = await _context.DetailOT.Where(d => d.OT_OTID == DetailOT.OT_OTID).FirstOrDefaultAsync(d => d.Employee_EmpID == DetailOT.Employee_EmpID);
            if (checkOT == null)
            {
                await addnewDetailOT();

            }
            else
            {
                ModelState.AddModelError("DetailOT.Employee_EmpID", "The user has been registered.");
                Defal = 1;
                try
                {
                    await OnLoad();
                }
                catch (Exception)
                {
                    return RedirectToPage("./index");
                }
                return Page();
            }
            
            Defal = 0;


            return RedirectToPage("./../listOTs/addOT");

        }

        private async Task addnewDetailOT()
        {
            DetailOT.OT_OTID = OT.OTID;
            _context.DetailOT.Add(DetailOT);
            await _context.SaveChangesAsync();
        }

        private async Task addnewOT()
        {
            OT.OT_CompanyID = Employee.Employee_CompanyID;
            _context.OT.Add(OT);
            await _context.SaveChangesAsync();
        }

        private async Task<int> checkTimeAsync(int check)
        {
            if (DetailOT.TimeStart == DetailOT.TimeEnd)
            {
                ModelState.AddModelError("timeError1", "The start time is less than the end time.");
                ModelState.AddModelError("timeError2", "The start time is less than the end time.");
                check = 1;

            }

            if (!DetailOT.Type.Equals("No") &&  getNamePartAsync(DetailOT.Part_PaetID).Equals("No"))
            {
                var partName = await getNamePartAsync(DetailOT.Part_PaetID);
                if (partName.Equals("No"))
                {
                    check = 1;
                ModelState.AddModelError("partError", "Please select a route.");

                }
                
               

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
            var GetDate = DateTime.Now;
            var date = new DateTime(GetDate.Year, GetDate.Month, GetDate.Day);
            if (OT.date < date)
            {
                check = 1;
                ModelState.AddModelError("OT.date", "Date is no less than the current.");

            } 
            return check;
        }

        private async Task<String> getNamePartAsync(int ID)
        {
            string namePart="";
            var part = await _context.Part.FirstOrDefaultAsync(u => u.PartID == ID);
               
            namePart = part.Name;
                
            
            return namePart;
        }
    }

    public class OTL
    {
        public OT OT { get; set; }
        public List<DetailOT> DetailOT { get; set; }

    }
}
