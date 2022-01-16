using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{ // טלפון של מצביע בבחירות 
    public class VoterPhoneInElections
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Elections Elections { get; set; }

        [Required]
        public Voter Voter { get; set; }

        // איזור בחירה
        public VotingArea VotingArea { get; set; }

        [Display(Name = "בחר במועמד")]
        public Candidate Candidate { get; set; }

        public List<Problem> Problems { get; set; }
    }
}