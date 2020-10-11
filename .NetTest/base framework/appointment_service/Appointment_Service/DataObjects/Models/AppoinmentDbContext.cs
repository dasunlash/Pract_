using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects.Models
{
   public class AppoinmentDbContext:DbContext
    {
        public AppoinmentDbContext(DbContextOptions<AppoinmentDbContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permissions> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

    }
}
