using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.ServiceLayer.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmployeeService _employeeService;
        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService)
        {
            this._appointmentService = appointmentService;
            this._employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsEmployee(long id)
        {
            return View("DetailsEmployee", _appointmentService.FindById(id));
        }
        public IActionResult DetailsCustomer(long id)
        {
            return View("DetailsCustomer", _appointmentService.FindById(id));
        }

        public async Task<IActionResult> Dashboard(DateTime? date)
        {
            IEnumerable<EmployeeDTO> employeesFound;
            try
            {
                employeesFound = await _employeeService.GetEmployeesWithAvailableTimeslots(date);
            }
            catch (Exception ex)
            {
                return View("Dashboard");
            }
            List<string> usernames = new();
            foreach (EmployeeDTO employee in employeesFound)
            {

                usernames.Add(employee.Username);
            }
            ViewData["EmployeeNameList"] = usernames;
            ViewData["TimeslotList"] = new List<int>() { 11, 12 };
            ViewData["JobTypeList"] = new List<string>() { "Massage" };
            return View();
        }

        public IActionResult EmployeeOverview()
        {
            return View();
        }

        public async Task<IActionResult> SaveAppointment(CreateAppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return View("Dashboard");
            }
            var result = await _appointmentService.Save(appointment);
            if (result != null && result.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
                ModelState.AddModelError("AppointmentCreatingFailed", UIErrorMessages.AppointmentCreationFailed);
                return View("Dashboard");
            }
        }
    }
}
