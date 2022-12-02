using AppointmentSchedulerUILibrary.AppointmentDTOs;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAppointmentService : ICrudService<CreateAppointmentDTO, GetAppointmentDTO, DeleteAppointmentDTO, long>
    {
    }
}
