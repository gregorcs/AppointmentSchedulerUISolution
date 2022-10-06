using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AppointmentSchedulerUI.Pages.NewFolder
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
        }

        //an async method must return a task
        public async Task<IActionResult> OnPostAsync()
        {
            //checks whether login.cshtml can bind info to its corresponding model
            if (!ModelState.IsValid) return Page();

            //checks if credentials are correct
            if (Credential.UserName == "admin" && Credential.Password == "admin")
            {
                //creation of a claim / cookie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name ="Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
