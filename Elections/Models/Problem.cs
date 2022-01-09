using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Problem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public VoterPhoneInElections VoterPhoneInElections { get; set; }
        public List<ProblemNotes> ProblemNotes { get; set; }

        [Display(Name = "האם נפתרה")]
        [Required]
        public bool Status { get; set; } = false;

        [Display(Name = "תוכן התקלה")]
        [Required]
        public string Description { get; set; }
    }
}