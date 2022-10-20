using AppointmentSchedulerUI.Controllers;
using AppointmentSchedulerUI.Pages.Account;
using AppointmentSchedulerUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentSchedulerUI.Pages
{
    public class SignupModel : PageModel
    {
        private readonly AccountController _accountController;

        public SignupModel(AccountController accountController)
        {
            _accountController = accountController;
        }

        [BindProperty]
        public SignupCredentials AccountToSave { get; set; }
        public void OnGet()
        {
        }

        public async Task<ViewResult> OnPostAsync()
        {
            //TODO enter some error thing here
            if (!ModelState.IsValid) return new ViewResult();
            return await _accountController.Save(AccountToSave);
        }
    }
}
