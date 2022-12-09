using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;

namespace AppointmentSchedulerUI.ServiceLayer.Interfaces
{
    public interface IAppointmentService : ICrudService<CreateAppointmentDTO, GetAppointmentDTO, DeleteAppointmentDTO, long>
    {

        Task<IEnumerable<GetAppointmentDTO>> GetAppointmentsByAccountId(long accountId);

        Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes();

        Task<int[]> GetTimeSlotsByDay(string date, long employeeId);
    }
}
