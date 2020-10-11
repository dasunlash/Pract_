using DataObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.DAL.Repository
{
   public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}
