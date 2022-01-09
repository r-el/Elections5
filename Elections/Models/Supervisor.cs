using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{ // מפקח
    public class Supervisor
    {
        [Key]
        public int ID { get; set; }

        [Required] // מקושר לטלפון של מצביע בבחירות
        public VoterPhoneInElections SupervisorID { get; set; }

        [Display(Name = "האם מפקח")]
        public bool IsSupervisor { get; set; } = true;
    }
}