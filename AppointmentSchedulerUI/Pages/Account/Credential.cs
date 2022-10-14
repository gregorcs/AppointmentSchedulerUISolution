using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUI.Pages.Account
{
    public class Credential
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
