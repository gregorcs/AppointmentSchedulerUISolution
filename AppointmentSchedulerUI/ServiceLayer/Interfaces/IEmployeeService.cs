using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.ServiceLayer.Interfaces
{
    public interface IEmployeeService : ICrudService<EmployeeDTO, EmployeeDTO, EmployeeDTO, long>
    {
        public Task<IEnumerable<EmployeeDTO>> GetEmployeesWithAvailableTimeslots(DateTime? date);
    }
}
