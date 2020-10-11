using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using DataObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Appointment_Service.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        private readonly IConfiguration _config;

        public LoginController(ILogin login, IConfiguration config)
        {
            _login = login;
            _config = config;
        }    
        [HttpPost,Route("AuthenticateUser")]
        public IActionResult AuthenticateUser(User user)
        {
            var userObj = _login.AuthenticateUser(user);
            var token = GenerateJSONWebToken(userObj);//if user is not block and success fully login
            return Ok(new { user = userObj, token = token });
        }

        public string GenerateJSONWebToken(User activeUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = ClaimUserDetails(activeUser);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(365),
            signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static Claim[] ClaimUserDetails(User activeUser)
        {
            return new[] {

                new Claim("UserName", activeUser.Name),
                new Claim("ApplicationId", activeUser.UserName),
                new Claim("Role", activeUser.RoleId.ToString()),
                new Claim("UserId", activeUser.Id.ToString()),
            };
        }
        [HttpGet, Route("GetUsers")]
        public IActionResult GetUsers()
        {
            
            return Ok(_login.GetUsers());
        }

        [HttpGet, Route("GetUsersName")]
        public IActionResult GetUsersName()
        {

            return Ok(_login.GetUsers());
        }
    }
}
