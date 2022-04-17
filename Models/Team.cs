using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectComp2084.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string TeamEstDate { get; set; }
        [Required]
        public string TeamCoach { get; set; }
        [Required]
        public int NumberOfChamps { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
