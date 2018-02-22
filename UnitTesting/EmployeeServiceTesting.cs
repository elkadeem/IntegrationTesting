using IntegrationTestingDemo.App;
using IntegrationTestingDemo.Core;
using IntegrationTestingDemo.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestFixture]
    public class EmployeeServiceTesting
    {
        [Test]
        public void GetEmployees_GetAllEmployees()
        {
            //Arrange
            var employees = new List<Employee> {
                    new Employee("Test", "Test", "1", DateTime.Today.AddYears(-19))
                };
            var loggerMock = new Mock<ILogger>();
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(c => c.GetEmployees())
                .Returns(() => employees);

            EmployeeService employeeService = new EmployeeService(employeeRepository.Object
                , loggerMock.Object);
            //Act
            var result = employeeService.GetEmployees();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);

        }


        [Test]
        public void GetEmployees_GetAllEmployees_WithoutSetup()
        {
            //Arrange
            var employees = new List<Employee> {
                    new Employee("Test", "Test", "1", DateTime.Today.AddYears(-19))
                };
            var loggerMock = new Mock<ILogger>();
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(c => c.GetEmployees())
                .Returns(() => employees);

            EmployeeService employeeService = new EmployeeService(employeeRepository.Object
                , loggerMock.Object);
            //Act
            var result = employeeService.GetEmployees();
            //Assert
            employeeRepository.Verify(c => c.GetEmployees(), Times.Once);                

        }


        [Test]
        public void GetEmployees_ThrowException_LogError()
        {
            //Arrange  
            var error = "Exception";
            //var exception = "";
            var loggerMock = new Mock<ILogger>();
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(c => c.GetEmployees())
                .Returns(() => throw new Exception(error));

            //loggerMock.Setup(c => c.Log(It.IsAny<Exception>()))
            //    .Callback<Exception>(c => exception = c.Message);

            EmployeeService employeeService = new EmployeeService(employeeRepository.Object
                , loggerMock.Object);
            //Act            
            Assert.Throws<Exception>(() => employeeService.GetEmployees());
            loggerMock.Verify(c => c.Log(It.IsAny<Exception>()), Times.Once);
            //Assert.AreEqual(error, exception);
        }
    }
}
