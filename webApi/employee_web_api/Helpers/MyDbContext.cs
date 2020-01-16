using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_web_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_web_api.Helpers
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
