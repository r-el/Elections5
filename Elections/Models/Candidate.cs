using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Candidate
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם מלא")]
        [Required]
        public string FullName { get; set; }

        public Elections Elections { get; set; }

        public List<VoterPhoneInElections> Voters { get; set; }
    }
}