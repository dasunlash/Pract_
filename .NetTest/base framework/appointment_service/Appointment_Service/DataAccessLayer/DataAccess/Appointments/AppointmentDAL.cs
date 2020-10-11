using DataAccessLayer.Repository;
using DataObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DataAccess.Appointments
{
    public class AppointmentDAL : IAppointment
    {

        private readonly AppoinmentDbContext _appoinmentDbContext;
        public AppointmentDAL(AppoinmentDbContext appoinmentDbContext)
        {
            _appoinmentDbContext = appoinmentDbContext;
        }
        public void SaveAppointment(Appointment appointment)
        {
            try
            {
                if (appointment.Id > 0)
                {
                    appointment.ModifiedDate = DateTime.Now;

                    _appoinmentDbContext.Entry(appointment).State = EntityState.Modified;
                    _appoinmentDbContext.SaveChanges();
                }
                else
                {
                    appointment.CreatedDate = DateTime.Now;
                    _appoinmentDbContext.Add(appointment);
                    _appoinmentDbContext.SaveChanges();
                }
                appointment.User = _appoinmentDbContext.User.FirstOrDefault(x => x.Id == appointment.AppointedUserId);


            }
            catch (Exception ex)
            {

                throw new Exception("Unabele to save appointments");
            }
        }
        public List<Appointment> GetAppointments(int? userId)
        {
            try
            {
                if (userId>-1)
                {
                    return _appoinmentDbContext.Appointment.Include(x => x.User).Where(x => x.AppointedUserId == userId).ToList();
                }
                return _appoinmentDbContext.Appointment.Include(x => x.User).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Unabele to get appointments");
            }
        }
        public Appointment GetAppointmentById(int appointmentId)
        {
            try
            {

                return _appoinmentDbContext.Appointment.Include(x=>x.User).FirstOrDefault(x => x.Id == appointmentId);
            }
            catch (Exception ex)
            {

                throw new Exception("Unabele to get appointment");
            }
        }
        public void DeleteAppointments(int id)
        {
            try
            {
                var appointments = _appoinmentDbContext.Appointment.FirstOrDefault(x => x.Id == id);
                _appoinmentDbContext.Remove(appointments);
                _appoinmentDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Unabele to delete appointments");
            }
        }
    }
}
