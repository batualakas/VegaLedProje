using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VegaLedProje.Business.Services;
using VegaLedProje.Data.Entities;
using VegaLedProje.Models;

namespace VegaLedProje.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            var user = _userService.Login(formData.UserName, formData.Password);
            if (user is null)
            {
                TempData["LoginMessage"] = "Kullanıcı adı ve ya şifre hatalı girildi";
                return RedirectToAction("Index", "Login");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("userName", user.UserName));
            claims.Add(new Claim("userType", user.UserType.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(5))
            };
            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimIdentity),
              autProperties);

            return RedirectToAction("Index", "OurServices", new { area = "Admin" });
        }

    }
}
