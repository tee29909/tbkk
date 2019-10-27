using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class OT
    {
        [Key]
        public int OTID { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeStart { get; set; }
        

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]

        public DateTime TimeEnd { get; set; }


        
        public string TypeOT { get; set; }
        
        [Display(Name = "TypeStatus")]
        public string TypStatus { get; set; }
    }
}
