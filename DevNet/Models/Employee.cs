using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevNet.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must to be from 3 to 50 character")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must to be from 3 to 50 character")]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,5}", ErrorMessage = "Wrong text. Please type valid formate")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Wrong number. Please type valid formate")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Required]
        [Range(18,62)]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}
