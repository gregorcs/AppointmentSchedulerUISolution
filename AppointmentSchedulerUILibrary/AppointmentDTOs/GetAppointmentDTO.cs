using AppointmentSchedulerUILibrary.DataTransferObjects;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AppointmentSchedulerUILibrary.AppointmentDTOs
{
    public class GetAppointmentDTO
    {
        public long Id { get; set; }
        
        public DateTime Date { get; set; }
        [Display(Name = "Time")]
        public int TimeSlot { get; set; }
        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [Display(Name = "Procedure")]
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetEmployeeDTO> Employees { get; set; }

        public GetAppointmentDTO(long id, DateTime date, int timeSlot, bool isApproved, string name, string description)
        {
            Id = id;
            Date = date;
            TimeSlot = timeSlot;
            IsApproved = isApproved;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $" {Name}, {Date}, {Username}";
        }
    }
}
