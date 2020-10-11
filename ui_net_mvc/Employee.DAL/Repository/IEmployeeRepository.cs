using System;
using System.Collections.Generic;
using System.Linq;
using DataObject;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Repository
{
   public interface IEmployeeRepository
    {
        Employee GetEmployees();
    }
}
