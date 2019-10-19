using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }

        public string PositionName { get; set; }
    }
}
