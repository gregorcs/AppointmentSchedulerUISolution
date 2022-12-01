﻿using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.Views;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.Repositories.Implementations
{
    public class AppointmentService : IAppointmentService
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

        public Task<IEnumerable<AppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
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

        public async Task<RestResponse> Save(AppointmentDTO entity)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            if (!httpContextAccessor.HttpContext.User.IsInRole("Admin") 
                || !httpContextAccessor.HttpContext.User.IsInRole("User"))
            {
                return null;
            }

            using var client = new RestClient(ServerUrl.EmployoeeUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);
            var body = JsonSerializer.Serialize(entity);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            return await client.ExecuteAsync(request);
        }
    }
}