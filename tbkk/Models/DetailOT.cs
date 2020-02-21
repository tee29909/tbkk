using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class DetailOT
    {
        [Key]
        public int DetailOTID { get; set; }

        [Required]
        [Display(Name = "Time Start")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime TimeStart { get; set; }


        [Required]
        [Display(Name = "Time End")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime TimeEnd { get; set; }


        [Required]
        [Display(Name = "Hour")]
        public TimeSpan Hour { get; set; }

        [Required]
        [Display(Name = "Travel Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        
        [Display(Name = "Part")]
        [ForeignKey("Part")]
        [Required]
        public int Part_PaetID { get; set; }
        public Part Part { get; set; }

        
        [Display(Name = "Food Set")]
        [ForeignKey("FoodSet")]
        [Required]
        public int FoodSet_FoodSetID { get; set; }
        public FoodSet FoodSet { get; set; }




        
        [Display(Name = "OT")]
        [ForeignKey("OT")]
        [Required]
        public int OT_OTID { get; set; }
        public OT OT { get; set; }

        
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        [Required]
        public int Employee_EmpID { get; set; }
        public Employee Employee { get; set; }

        
        [Display(Name = "Employee")]
        [ForeignKey("EmployeeAdd")]
        [Required]
        public int Employee_UserAdd_EmpID { get; set; }
        public Employee EmployeeAdd { get; set; }
    }
}
