using AppointmentSchedulerUI.Controllers;
using AppointmentSchedulerUILibrary;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAccountRepository : ICrudRepository<SignupCredentials, int>
    {
        public Task<bool> VerifyCredentials(Credential credential);

    }
}
