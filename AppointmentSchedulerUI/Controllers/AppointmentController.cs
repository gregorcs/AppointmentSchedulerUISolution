using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentDAO;
        public AppointmentController(IAppointmentService appointmentDAO)
        {
            this._appointmentDAO = appointmentDAO;
        }

        public IActionResult Index()
        {
            //rest client asks for data - sends it to the view
            //list current appointments
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> SaveAppointment(AppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterAccount", appointment);
            }
            var result = await _appointmentDAO.Save(appointment);
            if (result.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
/*                ModelState.AddModelError("ConfirmPassword", UIErrorMessages.AccountCreationFailed);
*/                return View("Dashboard", appointment);
            }
        }

    }
}
