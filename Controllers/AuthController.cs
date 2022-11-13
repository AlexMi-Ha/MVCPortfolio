using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCPortfolio.Controllers {
    [Route("Auth")]
    public class AuthController : Controller {

        [Route("Login")]
        public async Task<IActionResult> Login() {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Test"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return View();
        }

        [Route("Unauthorized")]
        public IActionResult Unauthorize() {
            return View();
        }
    }
}
