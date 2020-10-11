using DataAccessLayer.Repository;
using DataObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.DataAccess.Login
{
   public class LoginDAL: ILogin
    {
        private readonly AppoinmentDbContext _appoinmentDbContext;
        public LoginDAL(AppoinmentDbContext appoinmentDbContext)
        {
            _appoinmentDbContext = appoinmentDbContext;
        }

        public User AuthenticateUser(User user)
        {
            try
            {

                return _appoinmentDbContext.User.Include(x => x.Role).
                    FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password && x.IsActive==true);

            }
            catch (Exception ex)
            {

                throw new Exception("Unabele auhtnticateUser");
            }
        }

        public List<User> GetUsers()
        {
            try
            {

                var users=_appoinmentDbContext.User.Include(x => x.Role).Where(x => x.Role.Name != "CompanyUser").ToList();
                return users;

            }
            catch (Exception ex)
            {

                throw new Exception("Unabele auhtnticateUser");
            }
        }
    }
}
