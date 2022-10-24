using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary;
using AppointmentSchedulerUILibrary.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult RegisterAccount()
        {
            return View();
        }

        public async Task<IActionResult> Create(SignupCredential credential)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterAccount", credential);
            }
            var result = await _accountRepository.Save(credential);
            if (result.IsSuccessStatusCode)
            {
                return await Verify(credential);
            } else
            {
                ModelState.AddModelError("ConfirmPassword", UIErrorMessages.AccountCreationFailed);
                return View("RegisterAccount", credential);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Verify(Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", credential);
            }
            if (await _accountRepository.VerifyCredentials(credential))
            {
                var principal = CookieHandler.CreateCookie(credential.Email);
                await HttpContext.SignInAsync(CookieHandler.CookieName, principal);
                return RedirectToAction("LoggedIn");
            } else
            {
                ModelState.AddModelError("password", UIErrorMessages.IncorrectCredentials);
                return View("Login", credential);
            }
        }
        public IActionResult LoggedIn()
        {
            return User.Identity.IsAuthenticated ? View() : RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("", "Home");
        }

        public async Task<IActionResult> ListOfUsers()
        {
            var result = await _accountRepository.FindAll();
            return View(result);
        }
    }
}
