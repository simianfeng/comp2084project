using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectComp2084.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string Score { get; set; }
        [Required]
        public int TeamID { get; set; }

        [ForeignKey("TeamID")]
        public Team Team { get; set; }
    }
}
