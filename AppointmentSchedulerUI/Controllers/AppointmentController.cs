using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentDAO _appointmentDAO;
        public AppointmentController(IAppointmentDAO appointmentDAO)
        {
            this._appointmentDAO = appointmentDAO;
        }

        /*
         * 
         * Views
         * 
         */

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AppointmentOverview()
        {
            return View();
        }

        /*
         * 
         * CRUD
         * 
         */

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
