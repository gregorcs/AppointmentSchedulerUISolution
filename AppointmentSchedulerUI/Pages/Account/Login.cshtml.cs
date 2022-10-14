using AppointmentSchedulerUI.Pages.Account;
using AppointmentSchedulerUI.Pages.Api_calls;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AppointmentSchedulerUI.Pages.NewFolder
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return Page();
                }
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            return await Login();
        }

        public async Task<IActionResult> Login()
        {
            if (await AuthenticateLogin.VerifyCredentials(Credential))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Credential.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToPage("/Index");
            } else
            {
                return Page();
            }
        }
    }
}
