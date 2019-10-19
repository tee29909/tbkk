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

        [DataType(DataType.Date)]
        public DateTime TimeStart { get; set; }

        [DataType(DataType.Date)]

        public DateTime TimeEnd { get; set; }

        public string TypeOT { get; set; }
        public string TypStatus { get; set; }
    }
}
