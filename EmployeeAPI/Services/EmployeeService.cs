// Services/EmployeeService.cs
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> SearchEmployeesByName(string name);
        Employee AddEmployee(Employee employee);
        void RemoveEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;

        public EmployeeService()
        {
            _employees = MockData.Employees;
        }

        public IEnumerable<Employee> SearchEmployeesByName(string name)
        {
            return _employees.Where(e => e.FullName.Contains(name));
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public void RemoveEmployee(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
                _employees.Remove(employeeToRemove);
        }
    }
}
