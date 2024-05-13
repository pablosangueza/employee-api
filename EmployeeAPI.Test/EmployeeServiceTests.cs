// Tests/EmployeeServiceTests.cs
using System.Linq;
using EmployeeAPI.Services;
using Xunit;

namespace EmployeeAPI.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void SearchEmployeesByName_ReturnsCorrectEmployees()
        {
            // Arrange
            MockData.LoadMockData();
            var service = new EmployeeService();

            // Act
            var result = service.SearchEmployeesByName("John Doe");

            // Assert
            Assert.Single(result);
            Assert.Equal("John Doe", result.First().FullName);
        }

        [Fact]
        public void AddEmployee_IncreasesEmployeeCount()
        {
            // Arrange
            MockData.LoadMockData();
            var service = new EmployeeService();
            var initialCount = service.SearchEmployeesByName("").Count();

            // Act
            var newEmployee = new Employee { Id = 4, FullName = "Emily Brown", Birth = "1998-03-10" };
            service.AddEmployee(newEmployee);

            // Assert
            var updatedCount = service.SearchEmployeesByName("").Count();
            Assert.Equal(initialCount + 1, updatedCount);
        }
    }
}
