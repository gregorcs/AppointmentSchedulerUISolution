using AppointmentSchedulerUI.Pages.Account;

namespace AppointmentSchedulerUI.Repositories
{
    public interface IAccountRepository : ICrudRepository<SignupCredentials, int>
    {
    }
}
