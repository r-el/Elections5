using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class ProblemNotes
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Problem Problem { get; set; }

        [Required]
        public VoterPhoneInElections Supervisor { get; set; }

        [Display(Name = "הערות על תקלה")]
        [Required]
        public string Content { get; set; }
    }
}