using employee_web_api.Entities;
using employee_web_api.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace employee_web_api.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employee()
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
                new Employee()
                {
                    Id = 2,
                    FirstName = "Gaurav",
                    LastName = "Kumar",
                    DepartmentId = 2,
                    Designation = "Designation Two",
                    EmployeeType = 2,
                    ManagerName = "Second Manager",
                    Notes = "Second Notes"
                }
            );
            context.SaveChanges();
        }
    }
}
