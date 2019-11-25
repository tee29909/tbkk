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
        
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]

        public DateTime TimeStart { get; set; }
        
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]

        public DateTime TimeEnd { get; set; }
        public double Hour { get; set; }
        public string Type { get; set; }
        public string CarNumber { get; set; }

        public string Status { get; set; }

        [ForeignKey("Part")]
        public int Part_PaetID { get; set; }
        public Part Part { get; set; }

        [ForeignKey("FoodSet")]
        public int FoodSet_FoodSetID { get; set; }
        public FoodSet FoodSet { get; set; }
        
        [ForeignKey("CarType")]
        public int CarType_CarTypeID { get; set; }
        public CarType CarType { get; set; }
        [ForeignKey("OT")]
        public int OT_OTID { get; set; }
        public OT OT { get; set; }


        [ForeignKey("Employee")]
        public int Employee_EmpID { get; set; }
        public Employee Employee { get; set; }

    }
}
