using AppointmentSchedulerUILibrary;
using AppointmentSchedulerUILibrary.Credentials;
using RestSharp;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAccountRepository : ICrudRepository<SignupCredential, int>
    {
        public Task<AccountDetails> Authenticate(LoginCredential credential);
        public Task<RestResponse> SaveEmployee(EmployeeSignupCredential credential);
    }
}
