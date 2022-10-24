using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulerUILibrary.Cookies
{
    public class CookieHandler
    {
        public const string CookieName = "AppointmentCookie";
        public static ClaimsPrincipal CreateCookie(string email)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                };
            var identity = new ClaimsIdentity(claims, CookieName);
            return new(identity);
        }
    }
}
