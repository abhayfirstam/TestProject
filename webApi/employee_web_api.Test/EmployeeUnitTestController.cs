using employee_web_api.Controllers;
using employee_web_api.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using employee_web_api.Entities;

namespace employee_web_api.Test
{
    public class EmployeeUnitTestController
    {
        private  MyDbContext _context;
        public static DbContextOptions<MyDbContext> dbContextOptions { get; }
        static EmployeeUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("test")
                .Options;
        }
        public EmployeeUnitTestController()
        {
            var context = new MyDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
            _context = context;
        }
        #region Get By Id  

        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(_context);
            var postId = 2;

            //Act  
            var data = await controller.GetEmployee(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
             var controller = new EmployeesController(_context);
            var postId = 3;

            //Act  
            var data = await controller.GetEmployee(postId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeesController(_context);
            int? postId = null;

            //Act  
            var data = await controller.GetEmployee(postId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange  
            var controller = new EmployeesController(_context);
            int? postId = 1;

            //Act  
            var data = await controller.GetEmployee(postId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var emp = okResult.Value.Should().BeAssignableTo<Employee>().Subject;
            Assert.Equal("Abhay", emp.FirstName);
            Assert.Equal("Mondal", emp.LastName);
        }

        #endregion
    }
}
