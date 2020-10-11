using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using mvc_core_3._0.Models;

namespace mvc_core_3._0.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction("Login");
            }
            user.Username = "Admin";
            user.Password = "password";
            if (user.Username == "Admin" && user.Password == "password")
            {

                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Json("as");
            }

            return View();
        }
    }

}
