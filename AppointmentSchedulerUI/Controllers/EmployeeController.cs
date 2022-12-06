using AppointmentSchedulerUI.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetEmployeesWithAvailableTimeslots(DateTime? dateOfAppointment)
        {
            var result = await _employeeService.GetEmployeesWithAvailableTimeslots(dateOfAppointment);
            return View(result);
        }
    }
}
