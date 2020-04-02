using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class LineToken
    {
        [Key]
        public int LineTokenID { get; set; }
        [Required]
        public string TokenCar { get; set; }
        [Required]
        public string TokenFood { get; set; }

        [ForeignKey("Company")]
        public int Company_CompanyID { get; set;}
        public Company Company { get; set; }
    }
}
