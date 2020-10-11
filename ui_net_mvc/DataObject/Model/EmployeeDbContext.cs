using DataObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.Model
{
   public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext():base("name=my_connection")
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }

}
