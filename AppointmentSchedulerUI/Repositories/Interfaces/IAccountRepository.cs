using AppointmentSchedulerUILibrary;

namespace AppointmentSchedulerUI.Repositories.Interfaces
{
    public interface IAccountRepository : ICrudRepository<SignupCredential, int>
    {
        public Task<string> Authenticate(Credential credential);

    }
}
