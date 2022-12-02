// using AppointmentSchedulerUI.DataAccessLayer.IAccountDAO;
using AppointmentSchedulerUI.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.AppointmentDTOs
{
    public class AppointmentDTO
    {
        [Required, Display(Name = "Time")]
        public DateTime Time { get; set; }

        [Required, Display(Name = "Type")]
        [StringLength(50, ErrorMessage = UIErrorMessages.LengthExceeded)]
        public string Type { get; set; }

        // [Required, Display(Name = "Customer")]
        // public string IAccountDAO. { get; set; }

        // [Required, Display(Name = "Employee")]
        // public string Employee { get; set; }

        // [Required, Display(Name = "Appointment Status")]
        // public Boolean IsAccepted { get; set; }
    }
}
