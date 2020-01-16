using employee_web_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_web_api.Helpers
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>()))
            {
                if (context.Employees.Any())
                {
                    return;
                }
                context.Employees.AddRange(
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Abhay",
                        LastName = "Mondal",
                        DepartmentId = 1,
                        Designation = "Designation One",
                        EmployeeType = 1,
                        ManagerName = "First Manager",
                        Notes = "First Notes"

                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Gaurav",
                        LastName = "Kumar",
                        DepartmentId = 2,
                        Designation = "Designation Two",
                        EmployeeType = 2,
                        ManagerName = "Second Manager",
                        Notes = "Second Notes"
                    });

                context.SaveChanges();
            }
        }
    }
}
