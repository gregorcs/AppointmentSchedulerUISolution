using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.AppointmentDTOs
{
    public class GetAppointmentDTO
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public int TimeSlot { get; set; }
        public bool IsApproved { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ArrayList EmployeeNameList { get; set; }

        public GetAppointmentDTO()
        {

        }

        public GetAppointmentDTO(long id, DateTime time, int timeSlot, bool isApproved, string name, string description)
        {
            Id = id;
            Time = time;
            TimeSlot = timeSlot;
            IsApproved = isApproved;
            Name = name;
            Description = description;
            EmployeeNameList = new ArrayList();
        }
    }
}
