using IntegrationTestingDemo.App;
using IntegrationTestingDemo.Core;
using IntegrationTestingDemo.Domain;
using IntegrationTestingDemo.Infra;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private EmployeeService _employeeService;
        private readonly ILogger _logger = new Logger();

        [OneTimeSetUp]
        public void  Initiate()
        {
            EmployeesDbContext employeesDbContext = new EmployeesDbContext("EmployeeConnectionString");
            EmployeeRepository employeeRepository = new EmployeeRepository(employeesDbContext);

            _employeeService = new EmployeeService(employeeRepository, _logger);

            AddEmployees(employeesDbContext);
        }

        private static void AddEmployees(EmployeesDbContext employeesDbContext)
        {
            employeesDbContext.Employees.AddOrUpdate(c => c.IdNo, new Employee("Ahmed", "Dev", "111", DateTime.Today.AddYears(-30)));
            employeesDbContext.Employees.AddOrUpdate(c => c.IdNo, new Employee("Mohamed", "Dev", "112", DateTime.Today.AddYears(-30)));
            employeesDbContext.Employees.AddOrUpdate(c => c.IdNo, new Employee("Ali", "Dev", "123", DateTime.Today.AddYears(-30)));
            employeesDbContext.Employees.AddOrUpdate(c => c.IdNo
            , new Employee("Mahmoud", "Dev", "124", DateTime.Today.AddYears(-30)));

            employeesDbContext.SaveChanges();
        }

        [Test]
        public void GetEmployee_ReturnAllEmployees()
        {
            var items = _employeeService.GetEmployees();
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(items);
        }
    }
}
