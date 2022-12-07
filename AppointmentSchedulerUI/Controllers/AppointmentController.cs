using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.ServiceLayer.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

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
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Id");

            //get all the appointment data
            appointment.Date = Request.Cookies["date"];
            appointment.AppointmentTypeId = Convert.ToInt64(Request.Cookies["jobType"]);
            appointment.EmployeeId = Convert.ToInt64(Request.Cookies["employeeId"]);
            appointment.CustomerId = Convert.ToInt64(claim.Value);
            appointment.EmployeeIdList = new Collection<long>();
            appointment.EmployeeIdList.Add(Convert.ToInt64(Request.Cookies["employeeId"]));
            appointment.IsApproved = false;

            var result = await _appointmentService.Save(appointment);
            if (result != null && result.IsSuccessStatusCode)
            {
                return View("Index");
            }
            else
            {
                //todo add some error view here
                return View("Index");
            }
        }

        public async Task<IActionResult> DashboardAppointmentType()
        {
            IEnumerable<AppointmentTypeDTO> typesFound;
            try
            {
                typesFound = await _appointmentService.GetAllAppointmentTypes();
            }
            catch(Exception ex)
            {
                return View("Index");
            }
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
            Response.Cookies.Append("jobType", appointment.AppointmentTypeId.ToString());
            ViewBag.EmployeeNameList = employeesFound;
            return View(appointment);
        }

        public async Task<IActionResult> DashboardCalendar(CreateAppointmentDTO appointment)
        {
            Response.Cookies.Append("employeeId", appointment.EmployeeId.ToString());
            return View(appointment);
        }

        public async Task<IActionResult> DashboardTimeslot(CreateAppointmentDTO appointment)
        {
            IEnumerable<int> timeSlotsFound;
            string employeeIdString = Request.Cookies["employeeId"];
            Response.Cookies.Append("date", appointment.Date.ToString());
            try
            {
                timeSlotsFound = await _appointmentService
                    .GetTimeSlotsByDay(appointment.Date, Convert.ToInt64(employeeIdString));
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
