using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class CarQueue
    {
        [Key]
        public int CarQueueID { get; set; }
        [Display(Name = "Car Number")]
        public int CarNumber { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm:ss}")]
        public DateTime Time { get; set; }

        [ForeignKey("OT")]
        public int CarQueue_OTID { get; set; }
        public OT OT { get; set; }

        [Display(Name = "Car Type")]
        [ForeignKey("CarType")]
        public int CarQueue_CarTypeID { get; set; }
        public CarType CarType { get; set; }

        [Display(Name = "Part")]
        [ForeignKey("Part")]
        public int CarQueue_PartID { get; set; }
        public Part Part { get; set; }
    }
}
