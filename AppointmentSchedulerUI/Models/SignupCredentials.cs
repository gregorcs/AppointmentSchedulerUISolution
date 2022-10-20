using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUI.Pages.Account
{
    public class SignupCredentials
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
