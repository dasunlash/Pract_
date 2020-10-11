using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repository;
using DataObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Service.Controllers
{
    [Route("api/Appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointment _appointment;
        public AppointmentsController(IAppointment appointment)
        {
            _appointment = appointment;
        }
        [HttpGet, Route("GetAppointments")]
        public IActionResult GetAppointments(int ? userId)
        {
            return Ok(_appointment.GetAppointments(userId));
        }
        [HttpGet, Route("GetAppointmentById")]
        public IActionResult GetAppointmentById(int appointmentId)
        {
            return Ok(_appointment.GetAppointmentById(appointmentId));
        }
        [HttpPost, Route("SaveAppointment")]
        public IActionResult SaveAppointment(Appointment appointment)
        {
           
            //if (HttpContext.Session.GetString("User") != null)
            //{
                 //var obj= Newtonsoft.Json.JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("User"));
                _appointment.SaveAppointment(appointment);
                return Ok(appointment);
            //}
            //return BadRequest("Not valid user");
        }
        [HttpGet, Route("DeleteAppointment")]
        public IActionResult DeleteAppointment(int id)
        {
            _appointment.DeleteAppointments(id);
            return Ok(id);
        }
    }
}
