using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAppointmentService : ICrudService<CreateAppointmentDTO, GetAppointmentDTO, DeleteAppointmentDTO, long>
    {

        Task<IEnumerable<GetAppointmentDTO>> GetAppointmentsByAccountId(long accountId);

        Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes();

        Task<int[]> GetTimeSlotsByDay(string date, long employeeId);
    }
}
