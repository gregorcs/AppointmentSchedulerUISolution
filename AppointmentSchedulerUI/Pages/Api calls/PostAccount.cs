using AppointmentSchedulerUI.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.Pages.Api_calls
{
    public class PostAccount : PageModel
    {
        public async Task<IActionResult> PostAccountAsync(SignupCredentials accountToSave)
        {
            var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("create-account", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize(accountToSave);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return RedirectToPage("/index");
        }
    }
}
