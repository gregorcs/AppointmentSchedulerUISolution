using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.AppointmentDTOs
{
    public class DeleteAppointmentDTO
    {
        public long AppointmentId { get; set; }
        public long CustomerId { get; set; }
        public IEnumerable<long> EmployeeIds { get; set; }
    }
}
