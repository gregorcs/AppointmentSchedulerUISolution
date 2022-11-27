using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
