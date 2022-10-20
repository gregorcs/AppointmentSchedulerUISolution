using AppointmentSchedulerUI.Pages;
using AppointmentSchedulerUI.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RestResponse> Save(SignupCredentials credentials)
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("create-account", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize(credentials);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            return await client.ExecuteAsync(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async static Task<bool> VerifyCredentials(Credential credential)
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("authenticate", Method.Post);
            request.AddQueryParameter("email", credential.Email);
            request.AddQueryParameter("password", credential.Password);

            request.AddParameter("text/plain", ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            return response.IsSuccessStatusCode;
        }

        public Task Delete(SignupCredentials entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<SignupCredentials> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SignupCredentials>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SignupCredentials>> FindAllById(IEnumerable<int> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<SignupCredentials> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<SignupCredentials> entities)
        {
            throw new NotImplementedException();
        }
    }
}
