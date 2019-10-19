using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }

        public string Call { get; set; }
        public string Line { get; set; }
        public string Image { get; set; }
        public string Addr { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }



        [ForeignKey("Company")]
        public int Company_CompanyID { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Department")]
        public int Department_DepartmentID { get; set; }
        public Department Department { get; set; }

        [ForeignKey("Location")]
        public int Location_LocationID { get; set; }
        public Location Location { get; set; }

        [ForeignKey("EmployeeType")]
        public int EmployeeType_EmployeeTypeID { get; set; }
        public EmployeeType EmployeeType { get; set; }

        [ForeignKey("Position")]
        public int Position_PositionID { get; set; }
        public Position Position { get; set; }
    }
}
