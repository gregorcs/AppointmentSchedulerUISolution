using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAppointmentService : ICrudService<CreateAppointmentDTO, GetAppointmentDTO, DeleteAppointmentDTO, long>
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAndAvailableTimeSlots(DateTime date);

        Task<IEnumerable<GetAppointmentDTO>> GetAppointmentsByAccountId(long accountId);
    }
}
