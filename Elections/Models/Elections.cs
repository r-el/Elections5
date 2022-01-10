using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Elections
    {
        [Key]
        public int ID { get; set; }
        public Manager Manager { get; set; }

        [Display(Name="שם הבחירות")]
        [Required]
        public string Name { get; set; }

        [Display(Name="תאריך התחלה")]
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name="תאריך סיום")]
        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        [Display(Name="?האם ניתן לשנות בחירה")]
        [Required]
        public bool IsPossibleToChangeAVote { get; set; } = false;

        public List<VoterPhoneInElections> VoterPhoneInElections { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}