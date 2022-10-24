using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUILibrary.UIRegex;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUILibrary
{
    public class Credential
    {
        
        [Required]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        [RegularExpression(EmailRegex.Pattern, ErrorMessage = UIErrorMessages.InvalidEmail)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        public string Password { get; set; }
    }
}