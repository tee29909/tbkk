using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class OT
    {
        [Key]
        public int OTID { get; set; }

        
        [Display(Name = "Time Start")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: hh:mm tt}")]
        public DateTime TimeStart { get; set; }

        
        [Display(Name = "Time End")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: hh:mm tt}")]
        public DateTime TimeEnd { get; set; }

        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        
        [Display(Name = "Day")]
        public string TypeOT { get; set; }

        
        [Display(Name = "Status")]
        public string TypStatus { get; set; }



        [Display(Name = "Company")]
        [ForeignKey("Company")]

        public int? OT_CompanyID { get; set; }
        public Company Company { get; set; }



    }
}
