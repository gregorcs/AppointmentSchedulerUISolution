using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.Views;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Net;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.NetworkInformation;

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppointmentSchedulerUI.Repositories.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        public Task Delete(DeleteAppointmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<DeleteAppointmentDTO> entities)
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

        public Task<IEnumerable<GetAppointmentDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAppointmentDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAppointmentDTO> FindById(long id)
        {
            using var client = new RestClient(ServerUrl.AccountUrl + "/customer/" + id);
            var request = new RestRequest("", Method.Get);

            var response = await client.ExecuteAsync(request);

            var deserializedObject = JsonConvert.DeserializeObject<GetAppointmentDTO>(response.Content);

            return deserializedObject;
        }

        public Task<int> SaveAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<RestResponse> Save(CreateAppointmentDTO entity)
        {
            using var client = new RestClient(ServerUrl.AppointmentUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize(entity);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            return await client.ExecuteAsync(request);
        }
    }
}
