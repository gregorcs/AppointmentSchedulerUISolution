using AppointmentSchedulerUI.ServiceLayer.Interfaces;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace AppointmentSchedulerUI.ServiceLayer.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        public Task Delete(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll(IEnumerable<EmployeeDTO> entities)
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

        public Task<IEnumerable<EmployeeDTO>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> FindAllById(IEnumerable<long> Ids)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesWithAvailableTimeslots(DateTime? date)
        {
            var client = new RestClient("https://localhost:7052/api/v1/Appointment/2022-12-01");
            var request = new RestRequest("", Method.Get);
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var claim = httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "Bearer");
            request.AddHeader("Authorization", claim.Value);
/*            request.AddParameter(Parameter.CreateParameter("dateOfAppointment", date, ParameterType.GetOrPost));
*/            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Console.WriteLine(response.Content);
                return JsonSerializer.Deserialize<IEnumerable<EmployeeDTO>>(response.Content, options);
            } else
            {
                throw new Exception(response.ErrorMessage);
            }
        }

        public Task<RestResponse> Save(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAll(IEnumerable<EmployeeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
