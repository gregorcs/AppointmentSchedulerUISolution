using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUI.Views;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using AppointmentSchedulerUI.Exceptions;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Net;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
            using var client = new RestClient(ServerUrl.AppointmentUrl + "/" + id);
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new();

            var response = await client.ExecuteAsync(request);

            var appointment = JsonConvert.DeserializeObject<GetAppointmentDTO>(response.Content);

            return appointment;
        }

        public Task<int> SaveAll(IEnumerable<CreateAppointmentDTO> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<RestResponse> Save(CreateAppointmentDTO entity)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            using var client = new RestClient(ServerUrl.AppointmentUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);
            var body = JsonSerializer.Serialize(entity);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var result = await client.ExecuteAsync(request);
            return result;
        }

        public async Task<IEnumerable<GetAppointmentDTO>> GetAppointmentsByAccountId(long id)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            string role = "customer";

            //IF ITS EMPLOYEE ACCOUNT THEN YOU WILL GET IT BY EMPLOYEEID
            if (httpContextAccessor.HttpContext.User.IsInRole("Employee") || httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                role = "employee";
            }

            using var client = new RestClient(ServerUrl.AppointmentUrl + $"/{role}/{id}");
            var request = new RestRequest("", Method.Get);

            var response = await client.ExecuteAsync(request);

            var appointmentList = JsonConvert.DeserializeObject<IEnumerable<GetAppointmentDTO>>(response.Content);

            return appointmentList;
        }

        public async Task<IEnumerable<AppointmentTypeDTO>> GetAllAppointmentTypes()
        {
            using var client = new RestClient(ServerUrl.AppointmentUrl + "/types");
            var request = new RestRequest("", Method.Get);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Console.WriteLine(response.Content);
                return JsonSerializer.Deserialize<IEnumerable<AppointmentTypeDTO>>(response.Content, options);
            }
            else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        public async Task<int[]> GetTimeSlotsByDay(string date, long employeeId)
        {
            using var client = new RestClient(ServerUrl.AppointmentUrl + "/" + date);
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Console.WriteLine(response.Content);
                var listOfEmployees = JsonSerializer.Deserialize<List<EmployeeDTO>>(response.Content, options);
                foreach (EmployeeDTO employee in listOfEmployees)
                {
                    if (employee.Accounts_Id.Equals(employeeId))
                    {
                        return employee.Appointments;
                    }
                }
                return new int[0];
            } else
            {
                throw new Exception(response.ErrorMessage);
            }
        }
    }
}
