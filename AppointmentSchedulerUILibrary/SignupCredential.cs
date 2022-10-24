using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUILibrary.UIRegex;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary
{
    public class SignupCredential
    {
        [Required, Display(Name = "Name")]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        public string Password { get; set; }

        [Required, Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        [Compare("Password", ErrorMessage =UIErrorMessages.PasswordNotMatch)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        [RegularExpression(EmailRegex.Pattern, ErrorMessage = UIErrorMessages.InvalidEmail)]
        public string Email { get; set; }
    }
}
