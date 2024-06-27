// Controllers/EmployeesController.cs
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("HealthCheck")]
        public string HealthCheck()
        {
            return "Hello world from employee api";
        }

        [HttpGet("EmployeesByName")]
        public ActionResult<IEnumerable<Employee>> SearchEmployeesByName([FromQuery] string name)
        {
            var employees = _employeeService.SearchEmployeesByName(name);
            return Ok(employees);
        }
        [HttpGet("")]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost("AddEmployee")]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            var newEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(AddEmployee), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEmployee(int id)
        {
            _employeeService.RemoveEmployee(id);
            return NoContent();
        }
    }
}
