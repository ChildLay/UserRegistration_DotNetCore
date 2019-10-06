using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class UserRegisterViewModel
    {

        [Required]
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [StringLength(50, ErrorMessage = "Email length can't be more than 50.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        ////[Required]
        // [Display(Name = "Gender:")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date Registered:")]
        [Range(typeof(DateTime), "01/01/2019", "01/06/2019")]     
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]     
        public DateTime? RegisteredDate { get; set; }

     

        [Display (Name = "Additional Request:")]
        [StringLength(100, ErrorMessage = "AdditionalRequest length can't be more than 100.")]
        public string AdditionalRequest { get; set; }

        public bool Day1 { get; set; }
        public bool Day2 { get; set; }
        public bool Day3 { get; set; }
    }
}
