using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class AccountDetails
    {
        [Required]
        public string JwtToken { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public long Id { get; set; }
    }
}
