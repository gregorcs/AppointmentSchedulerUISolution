using AppointmentSchedulerUILibrary.DataTransferObjects;
using System.Security.Claims;

namespace AppointmentSchedulerUILibrary.Cookies
{
    public class CookieHandler
    {
        public const string CookieName = "AppointmentCookie";
        public static ClaimsPrincipal CreateUserCookie(string email, AccountDetails accountDetails)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", accountDetails.Id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim("Bearer", "bearer " + accountDetails.JwtToken),
                };
            var identity = new ClaimsIdentity(claims, CookieName);
            return new(identity);
        }

        public static ClaimsPrincipal CreateAdminCookie(string email, AccountDetails accountDetails)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", accountDetails.Id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("Bearer", "bearer " + accountDetails.JwtToken)
                };
            var identity = new ClaimsIdentity(claims, CookieName);
            return new(identity);
        }
    }
}
