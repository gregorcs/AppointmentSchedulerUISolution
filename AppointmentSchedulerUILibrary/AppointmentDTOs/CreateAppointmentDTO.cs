using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUILibrary.UIRegex;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.AppointmentDTOs
{
    public class CreateAppointmentDTO
    {
        public long CustomerId { get; set; }
        public string Date { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public long AppointmentTypeId { get; set; }
        public long AppointmentTypeName { get; set; }
        public Collection<long>? EmployeeIdList { get; set; }
        public long EmployeeId { get; set; }
    }
}
