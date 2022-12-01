using AppointmentSchedulerUILibrary.AppointmentDTOs;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAppointmentService : ICrudService<AppointmentDTO, long>
    {
    }
}
