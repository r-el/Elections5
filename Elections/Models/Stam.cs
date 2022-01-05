using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Stam
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string StamString { get; set; }
        [Required]
        public int StamInt { get; set; }
    }
}