using AppointmentSchedulerUI.Pages.Account;
using RestSharp;

namespace AppointmentSchedulerUI.Pages.Api_calls
{
    public class AuthenticateLogin
    {
        public async static Task<bool> VerifyCredentials(Credential credential)
        {
            var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("authenticate", Method.Post);
            request.AddQueryParameter("username", credential.UserName);
            request.AddQueryParameter("password", credential.Password);

            request.AddParameter("text/plain", ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return response.IsSuccessStatusCode;
        }
    }
}
