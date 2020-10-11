using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http.Authentication;
using mvc_logi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvc_logi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction("Login");
            }
            user.Username = "Admin";
            user.Password = "password";
            if (user.Username == "Admin" && user.Password == "password")
            {

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "asasa"),
                new Claim(ClaimTypes.Name,  "asasa"),
                new Claim(ClaimTypes.Role, "asasa")
            };

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new FormsAuthenticationTicket("asas", true, 24 * 3600 * 7);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    Path = FormsAuthentication.FormsCookiePath,
                    Value = FormsAuthentication.Encrypt(ticket),
                    Expires = ticket.Expiration
                };
                Response.Cookies.Add(cookie);
                return Json("1");
            }

            return View();
        }
    }
}