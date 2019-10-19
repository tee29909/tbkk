using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class DetailOT
    {
        [Key]
        public int DetailOTID { get; set; }

        [DataType(DataType.Date)]

        public DateTime TimeStart { get; set; }

        [DataType(DataType.Date)]

        public DateTime TimeEnd { get; set; }
        public string Hour { get; set; }
        public string Type { get; set; }
        public string CarNumber { get; set; }

        public string Status { get; set; }
    }
}
