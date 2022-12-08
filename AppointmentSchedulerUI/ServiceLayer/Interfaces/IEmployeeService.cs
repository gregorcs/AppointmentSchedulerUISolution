using AppointmentSchedulerUILibrary.DataTransferObjects;

namespace AppointmentSchedulerUI.ServiceLayer.Interfaces
{
    public interface IEmployeeService : ICrudService<EmployeeDTO, EmployeeDTO, EmployeeDTO, long>
    {
        public Task<IEnumerable<EmployeeDTO>> GetEmployeesWithAvailableTimeslots(DateTime? date);

        public Task<IEnumerable<GetEmployeeDTO>> GetEmployeeByAppointmentType(long id);
    }
}
