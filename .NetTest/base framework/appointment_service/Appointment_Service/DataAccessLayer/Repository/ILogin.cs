using DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repository
{
    public interface ILogin
    {
        User AuthenticateUser(User user);
        List<User> GetUsers();

    }
}
