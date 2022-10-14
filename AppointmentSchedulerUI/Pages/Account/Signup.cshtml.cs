using AppointmentSchedulerUI.Pages.Account;
using AppointmentSchedulerUI.Pages.Api_calls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentSchedulerUI.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public SignupCredentials AccountToSave { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            var postAccount = new PostAccount();
            return await postAccount.PostAccountAsync(AccountToSave);
        }
    }
}
