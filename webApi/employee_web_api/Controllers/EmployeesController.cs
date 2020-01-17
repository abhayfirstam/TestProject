using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_web_api.Entities;
using employee_web_api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_web_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EmployeesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            //return await _context.Employees.ToListAsync();

            try
            {
                var employees = await _context.Employees.ToListAsync();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = await _context.Employees.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Employees.OrderByDescending(u => u.Id).FirstOrDefault();
                    if (data != null)
                    {
                        employee.Id = data.Id + 1;
                    }
                    else
                    {
                        employee.Id = 1;
                    }
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    if (employee.Id > 0)
                    {
                        return Ok(employee.Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }


            //var employee = await _context.Employees.FindAsync(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //_context.Employees.Remove(employee);
            //await _context.SaveChangesAsync();

            //return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}