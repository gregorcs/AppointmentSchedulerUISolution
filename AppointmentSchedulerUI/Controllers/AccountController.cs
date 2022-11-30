using AppointmentSchedulerUI.Exceptions;
using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary;
using AppointmentSchedulerUILibrary.Cookies;
using AppointmentSchedulerUILibrary.Credentials;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSchedulerUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountDAO;

        public AccountController(IAccountService accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public IActionResult RegisterAccount()
        {
            return View();
        }

        public IActionResult RegisterEmployee()
        {
            return View();
        }

        public async Task<IActionResult> SaveUser(SignupCredential credential)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterAccount", credential);
            }
            var result = await _accountDAO.Save(credential);
            if (result.IsSuccessStatusCode)
            {
                return await Authenticate(credential);
            }
            else
            {
                ModelState.AddModelError("ConfirmPassword", UIErrorMessages.AccountCreationFailed);
                return View("RegisterAccount", credential);
            }
        }
        public async Task<IActionResult> SaveEmployee(EmployeeSignupCredential credential)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterEmployee", credential);
            }
            var result = await _accountDAO.SaveEmployee(credential);
            if (result != null && result.IsSuccessStatusCode)
            {
                return View("RegisterEmployee", credential);
            } else
            {
                ModelState.AddModelError("ConfirmPassword", UIErrorMessages.AccountCreationFailed);
                return View("RegisterEmployee", credential);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate(LoginCredential credential)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", credential);
            }
            AccountDetails response;
            try
            {
                response = await _accountDAO.Authenticate(credential);
            } catch (Exception ex)
            {
                //exception should be logged
                ModelState.AddModelError("password", ex.Message);
                return View("Login", credential);
            }
            if (response != null)
            {
                //this could be updated to not only hold either admin or user cookie
                //it could be expanded with various roles with relative ease (out of scope)
                var principal = response.Role.Equals("Admin")
                    ? CookieHandler.CreateAdminCookie(credential.Email, response)
                    : CookieHandler.CreateUserCookie(credential.Email, response);
                await HttpContext.SignInAsync(CookieHandler.CookieName, principal);
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("password", UIErrorMessages.IncorrectCredentials);
                return View("Login", credential);
            }
        }
        public IActionResult LoggedIn()
        {
            return User.Identity.IsAuthenticated ? RedirectToAction("Dashboard", "Appointment") : RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("", "Home");
        }

        public async Task<IActionResult> ListOfUsers() => View(await _accountDAO.FindAll());
    }
}
