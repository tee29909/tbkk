﻿using System;
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

        
        [Display(Name = "Time Start")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime TimeStart { get; set; }


        
        [Display(Name = "Time End")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime TimeEnd { get; set; }

        
        
        [Display(Name = "Hour")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c} Hour")]
        public TimeSpan Hour { get; set; }

        
        [Display(Name = "Travel Type")]
        public string Type { get; set; }

        
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Point")]
        [ForeignKey("Point")]
        
        public int Point_PointID { get; set; }
        public Point Point { get; set; }
        [Required]

        [Display(Name = "Food Set")]
        [ForeignKey("FoodSet")]
        
        public int FoodSet_FoodSetID { get; set; }
        public FoodSet FoodSet { get; set; }




        
        [Display(Name = "OT")]
        [ForeignKey("OT")]
       
        public int OT_OTID { get; set; }
        public OT OT { get; set; }

        
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        
        public int Employee_EmpID { get; set; }
        public Employee Employee { get; set; }



        [Display(Name = "Employee")]
        [ForeignKey("EmployeeAdd")]
        
        public int? Employee_UserAdd_EmpID { get; set; }
        public Employee EmployeeAdd { get; set; }



    }
}
