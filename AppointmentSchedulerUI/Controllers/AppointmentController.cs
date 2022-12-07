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
        private CreateAppointmentDTO currentAppointment;
        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService)
        {
            this._appointmentService = appointmentService;
            this._employeeService = employeeService;
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
            var testing = date;
            try
            {
                employeesFound = await _employeeService.GetEmployeesWithAvailableTimeslots(new DateTime(2022, 12, 1));
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

        public async Task<IActionResult> DashboardAppointmentType()
        {
            currentAppointment = new CreateAppointmentDTO();
            IEnumerable<AppointmentTypeDTO> typesFound;
            try
            {
                typesFound = await _appointmentService.GetAllAppointmentTypes();
            }
            catch(Exception ex)
            {
                return View("Index");
            }
            //List<AppointmentTypeDTO> types = new List<AppointmentTypeDTO>();
            //foreach(AppointmentTypeDTO type in typesFound)
            //{
            //    types.Add(type);
            //}
            //ViewData["JobTypeList"] = typesFound;
            ViewBag.JobTypeList = typesFound;

            return View();
        }

        public async Task<IActionResult> DashboardEmployee(CreateAppointmentDTO appointment)
        {
            currentAppointment = appointment;
            IEnumerable<GetEmployeeDTO> employeesFound;
            try
            {
                employeesFound = await _employeeService.GetEmployeeByAppointmentType(appointment.AppointmentTypeId);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
            //List<string> employees = new List<string>();
            //foreach (EmployeeDTO employee in employeesFound)
            //{
            //    employees.Add(employee.Username);
            //}
            //ViewData["EmployeeNameList"] = employeesFound;
            ViewBag.EmployeeNameList = employeesFound;
            return View(appointment);
        }

        public async Task<IActionResult> DashboardCalendar(CreateAppointmentDTO appointment)
        {
            currentAppointment.EmployeeId = appointment.EmployeeId;
            return View(appointment);
        }

        public async Task<IActionResult> DashboardTimeslot(CreateAppointmentDTO appointment)
        {
            List<int> timeSlotsFound;
            try
            {
                timeSlotsFound = await _appointmentService.GetTimeSlotsByDay(appointment.Date);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
            ViewData["TimeslotList"] = timeSlotsFound;
            return View(appointment);
        }
    }
}
