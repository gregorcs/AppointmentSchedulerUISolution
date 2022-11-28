using AppointmentSchedulerUILibrary.AppointmentDTOs;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAppointmentDAO : ICrudDAO<AppointmentDTO, long>
    {
    }
}
