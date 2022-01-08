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
        public VoterPhoneInElections VoterPhoneInElections { get; set; }

        [Display(Name = "תוכן התקלה")]
        [Required]
        public string Content { get; set; }
    }
}