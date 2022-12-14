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
        public AppointmentController(IAppointmentService appointmentService, IEmployeeService employeeService)
        {
            this._appointmentService = appointmentService;
            this._employeeService = employeeService;
        }

        public async Task<IActionResult> SaveAppointment(CreateAppointmentDTO appointment)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Id");

            //get all the appointment data
            appointment.Date = Request.Cookies["date"];
            appointment.CustomerId = Convert.ToInt64(claim.Value);
            appointment.AppointmentTypeId = Convert.ToInt64(Request.Cookies["jobType"]);
            appointment.EmployeeId = Convert.ToInt64(Request.Cookies["employeeId"]);
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
            catch (Exception ex)
            {
                return View("Index");
            }
            ViewBag.JobTypeList = typesFound;

            return View();
        }

        public async Task<IActionResult> DashboardEmployee(CreateAppointmentDTO appointment)
        {
            IEnumerable<GetEmployeeDTO> employeesFound;
            try
            {
                employeesFound = await _employeeService.GetEmployeeByAppointmentType(appointment.AppointmentTypeId);
            }
            catch (Exception ex)
            {
                return View("DashboardAppointmentType");
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
            if(appointment.Date == null)
            {
                return View("DashboardCalendar");
            }
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
            ViewBag.TimeSlotList = timeSlotsFound;
            return View(appointment);
        }

        public async Task<IActionResult> ViewCreatedAppointments()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Id");
            IEnumerable<GetAppointmentDTO> result;
            try
            {
                result = await _appointmentService.GetAppointmentsByAccountId(Convert.ToInt64(claim.Value));
            }
            catch (Exception ex)
            {
                return View("Index");
            }
            return View(result);
        }
    }
}
