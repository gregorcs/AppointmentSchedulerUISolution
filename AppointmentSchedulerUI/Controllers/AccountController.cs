using AppointmentSchedulerUI.Pages.Account;
using AppointmentSchedulerUI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public IActionResult Login()
        {
            return View();
        }

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ViewResult> Save(SignupCredentials credentials)
        {
            var result = await _accountRepository.Save(credentials);
            return View(result);
        }

        public IActionResult Authenticate(Credential credential)
        {
            return View();
        }
    }
}
