
using DataObject.Model;
using EmployeeMgt.DAL.DataAccess;
using EmployeeMgt.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController()
        {
            _employeeRepository = new EmployeeDAL(new EmployeeDbContext());
        }
        public ActionResult GetEmployee()
        {
            var a = _employeeRepository.GetEmployees();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}