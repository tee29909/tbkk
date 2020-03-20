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
    public class listEmpOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public listEmpOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }


        //public IList<DetailOT> DetailOT { get;set; }
        public OT OT { get; set; }


        public IList<listOT> listOT { get; set; }




        public Employee Employee { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                await OnLoad();
            }
            catch (Exception e)
            {
                RedirectToPage("../../index");
            }

        }

        private async Task OnLoad()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);



            var ListOTadd = new List<listOT>();

            var OTs = await _context.OT.Where(o => o.TypStatus.Equals("Open") && o.OT_CompanyID == Employee.Employee_CompanyID).ToListAsync();
            

            foreach (var item in OTs)
            {
                var add = new listOT();
                var detailOTs = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).Where(d => d.OT_OTID == item.OTID && d.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID && d.OT.OT_CompanyID == Employee.Employee_CompanyID).ToListAsync();
                add.OT = item;
                add.Emp_Cout = detailOTs.Count;
                detailOTs = detailOTs.Where(d => d.Status.Equals("Pending for approval") ).ToList();
                add.Emp_Manage = detailOTs.Count;

                ListOTadd.Add(add);
            }

            listOT = ListOTadd;



            


            //DetailOT = await _context.DetailOT
            //    .Include(d => d.Employee)
            //    .Include(d => d.FoodSet)
            //    .Include(d => d.OT)
            //    .Include(d => d.Part).ToListAsync();
            //DetailOT = DetailOT.Where(d => d.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID).ToList();
            //DetailOT = DetailOT.Where(d => d.Status.Equals("Pending for approval") && d.OT.OT_CompanyID == Employee.Employee_CompanyID).ToList();
            //OT = await _context.OT.ToListAsync();
            //OT = OT.Where(o => o.TypStatus.Equals("Open") && o.OT_CompanyID == Employee.Employee_CompanyID).ToList();
        }

        public async Task<IActionResult> OnPostAddAllAsync(int Did)
        {
            try
            {
                await OnLoad();
            }
            catch (Exception e)
            {
                return RedirectToPage("./index");
            }


            var newDetailOTs = await _context.DetailOT.Include(d => d.Employee).Where(n => n.OT_OTID == Did && n.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID).ToArrayAsync();
            foreach (var item in newDetailOTs)
            {
                DetailOT newDetailOT = item;
                newDetailOT.Status = "Allow";

                _context.Attach(newDetailOT).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOTExists(newDetailOT.DetailOTID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            

            return RedirectToPage("./../listOTs/listEmpOT");
        }

        private bool DetailOTExists(int id)
        {
            return _context.DetailOT.Any(e => e.DetailOTID == id);
        }
    }

    public class listOT { 
        public OT OT { get; set; }
        public int Emp_Cout { get; set; }
        public int Emp_Manage { get; set; }


    }

}
