using AppointmentSchedulerUILibrary.ErrorMessages;
using AppointmentSchedulerUILibrary.UIRegex;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class SignupCredential : LoginCredential
    {
        [Required, Display(Name = "Name")]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        [RegularExpression(UsernameRegex.Pattern, ErrorMessage = UIErrorMessages.InvalidUsername)]
        public string Username { get; set; }

        [Required, Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        [Compare("Password", ErrorMessage = UIErrorMessages.PasswordNotMatch)]
        public string ConfirmPassword { get; set; }
    }
}
