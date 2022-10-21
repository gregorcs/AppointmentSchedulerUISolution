using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppointmentSchedulerUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ViewResult> RegisterAccount(SignupCredential credentials)
        {
            var result = await _accountRepository.Save(credentials);
            return View();
        }

        public async Task<IActionResult> Login(Credential credential)
        {
            if (await _accountRepository.VerifyCredentials(credential))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, credential.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToAction("LoggedIn");
            }
            return View();
        }

        public IActionResult LoggedIn()
        {
            return User.Identity.IsAuthenticated ? View() : RedirectToAction("Login");
        } 

        public async Task<IActionResult> ListOfUsers()
        {
            var result = await _accountRepository.FindAll();
            return View(result);
        }
    }
}
