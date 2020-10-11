using DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
    public interface IAppointment
    {
        void SaveAppointment(Appointment appointment);
        List<Appointment> GetAppointments(int? userId);
        Appointment GetAppointmentById(int appointmentId);
        void DeleteAppointments(int id);
    }
}
