using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class VotingArea
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם האיזור")]
        [Required]
        public string Name { get; set; }

        [Required]
        public List<VoterPhoneInElections> Voters { get; set; }
    }
}