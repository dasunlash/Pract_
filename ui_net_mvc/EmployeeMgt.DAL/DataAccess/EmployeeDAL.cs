using DataObject.Model;
using EmployeeMgt.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.DAL.DataAccess
{
    public class EmployeeDAL : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeDAL(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public List<Employee> GetEmployees()
        {
            var employees = _employeeDbContext.Employee.ToList();
           return employees;

        }
    }
}
