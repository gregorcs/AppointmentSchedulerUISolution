using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.DataTransferObjects
{
    public class AccountDTO
    {
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int[]? Appointments { get; set; }

        public AccountDTO(string username, string email, string password, int[] appointments)
        {
            Username = username;
            Email = email;
            Password = password;
            Appointments = appointments;
        }

        public AccountDTO() { }
    }
}
