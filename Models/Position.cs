using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectComp2084.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        [Required]
        public string PositionName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int PositionLevel { get; set; }

        public int TeamID { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }
    }
}
