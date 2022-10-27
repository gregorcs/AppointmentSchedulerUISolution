using System.Security.Claims;

namespace AppointmentSchedulerUILibrary.Cookies
{
    public class CookieHandler
    {
        public const string CookieName = "AppointmentCookie";
        public static ClaimsPrincipal CreateCookie(string email, string token)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Role", "User"),
                    new Claim("Bearer", "bearer " + token)
                };
            var identity = new ClaimsIdentity(claims, CookieName);
            return new(identity);
        }

        public static ClaimsPrincipal CreateAdminCookie(string email, string token)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Role", "Admin"),
                    new Claim("Bearer", "bearer " + token)
                };
            var identity = new ClaimsIdentity(claims, CookieName);
            return new(identity);
        }
    }
}
