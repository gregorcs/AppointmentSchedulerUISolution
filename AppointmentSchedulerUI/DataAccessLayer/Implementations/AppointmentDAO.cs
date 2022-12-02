using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.Views;
using AppointmentSchedulerUILibrary;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.Repositories.Implementations
{
    public class AppointmentDAO : IAppointmentDAO
    {
        public Task Delete(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentDTO>> FindAll()
        {
            using var client = new RestClient(ServerUrl.AppointmentUrl);
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<IEnumerable<AppointmentDTO>>(response.Content, options) ??
                    Array.Empty<AppointmentDTO>();
            }
            return Array.Empty<AppointmentDTO>();
            //throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentDTO>> FindAllById(IEnumerable<long> id)
        {
            using var client = new RestClient(ServerUrl.AppointmentUrl + "/" + id);
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);

            var response = await client.ExecuteAsync(request);
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<AppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<RestResponse> Save(AppointmentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
