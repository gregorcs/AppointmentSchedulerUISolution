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
        public async Task<bool> VerifyCredentials(Credential credentials)
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("authenticate", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize(credentials);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = await client.ExecuteAsync(request);
            return response.IsSuccessStatusCode;
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

        public async Task<IEnumerable<SignupCredential>> FindAll()
        {
            using var client = new RestClient(ServerUrl.Url);
            var request = new RestRequest("", Method.Get);
            var response = await client.ExecuteAsync(request);
            var deserializedReponse = JsonSerializer.Deserialize<IEnumerable<SignupCredential>>(response.Content);
            //if deserializedResponse is not null then is returned, if not an empty array returned
            return deserializedReponse ?? (Array.Empty<SignupCredential>());
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
