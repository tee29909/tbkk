using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "LocationName")]
        public string LocationName { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
