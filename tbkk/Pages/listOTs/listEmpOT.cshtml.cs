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
            catch (Exception)
            {
                RedirectToPage("../../index");
            }

        }

        private async Task OnLoad()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);



            var ListOTadd = new List<listOT>();

            var OTs = await _context.OT.Where(o => o.TypStatus.Equals("Open") && o.OT_CompanyID == Employee.Company_CompanyID).ToListAsync();
            

            foreach (var item in OTs)
            {
                var add = new listOT();
                var detailOTs = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Point.Part).Where(d => d.OT_OTID == item.OTID && d.Employee.Department_DepartmentID == Employee.Department_DepartmentID && d.OT.OT_CompanyID == Employee.Company_CompanyID).ToListAsync();
                add.OT = item;
                add.Emp_Cout = detailOTs.Count;
                detailOTs = detailOTs.Where(d => d.Status.Equals("Allow") || d.Status.Equals("Disallow")).ToList();
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

       
    }

    public class listOT { 
        public OT OT { get; set; }
        public int Emp_Cout { get; set; }
        public int Emp_Manage { get; set; }


    }

}
