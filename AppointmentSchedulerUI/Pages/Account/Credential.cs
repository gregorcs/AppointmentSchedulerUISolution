using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUI.Pages.Account
{
    public class Credential
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
