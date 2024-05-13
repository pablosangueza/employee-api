// Data/MockData.cs
using System.Collections.Generic;

namespace EmployeeAPI
{
    public static class MockData
    {
        public static List<Employee> Employees = new List<Employee>();

        public static void LoadMockData()
        {
            LoadEmployees();
        }

        private static void LoadEmployees()
        {
            Employees.Add(new Employee { Id = 1, FullName = "John Doe", Birth = "1990-01-01" });
            Employees.Add(new Employee { Id = 2, FullName = "Jane Smith", Birth = "1995-05-15" });
            Employees.Add(   new Employee { Id = 3, FullName = "Michael Johnson", Birth = "1985-09-20" });

        }
    }
}
