using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Voter
    {
        [Key]
        [Display(Name = "מספר טלפון")]
        [RegularExpression(@"\d{10}", ErrorMessage = "אנא הזן מספר טלפון בעל 10 ספרות")] //[RegularExpression("([0-9]+)")]  // Only Nums
        [Required(ErrorMessage = "הזן מספר טלפון")]
        public string PhoneID { get; set; }

        [Display(Name = "שם מלא")]
        [RegularExpression("^[a-zA-Z ]*$")] // Only Chars
        [Required(ErrorMessage ="הזן שם מלא")]
        public string FullName { get; set; }

        [Display(Name = "כתובת מייל")]
        [Required(ErrorMessage = "הזן כתובת מייל")]
        [EmailAddress(ErrorMessage = "נא הכנס כתובת מייל נכונה")] // Only Email
        public string Mail { get; set; }

        [Display(Name = "סיסמא")]
        [Required(ErrorMessage = "הזן סיסמא")]
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,20})$", ErrorMessage = "סיסמא חייבת להיות עם מספרים ואותיות, בין 8 ל-10 ספרות ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "האם מפקח")]
        public bool IsSupervisor { get; set; } = false;
    }
}