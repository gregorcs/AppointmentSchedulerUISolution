using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.Views;
using AppointmentSchedulerUILibrary;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RestResponse> Save(SignupCredential credentials)
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
        public async Task<string> Authenticate(Credential credentials)
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("authenticate", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize(credentials);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return JsonSerializer.Deserialize<string>(response.Content, options);
            }
            else
            {
                throw new Exception();
            }
        }

        public Task Delete(SignupCredential entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<SignupCredential> entities)
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

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IEnumerable<SignupCredential>> FindAll()
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);
            var response = await client.ExecuteAsync(request);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<SignupCredential>>(response.Content, options) ??
                    Array.Empty<SignupCredential>();
            }

            return Array.Empty<SignupCredential>();
        }

        public Task<IEnumerable<SignupCredential>> FindAllById(IEnumerable<int> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<SignupCredential> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<SignupCredential> entities)
        {
            throw new NotImplementedException();
        }
    }
}
