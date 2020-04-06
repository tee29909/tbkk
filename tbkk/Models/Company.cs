using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class Company
    {
        
        public int CompanyID { get; set; }
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
