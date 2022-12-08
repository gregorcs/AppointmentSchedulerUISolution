using System.Collections.ObjectModel;

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
