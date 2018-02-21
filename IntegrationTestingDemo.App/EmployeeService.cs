using IntegrationTestingDemo.Core;
using IntegrationTestingDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.App
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger)
        {
            if (employeeRepository == null)
                throw new ArgumentNullException(nameof(employeeRepository));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public void AddEmployee(EmployeeViewModel employeeModel)
        {
            try
            {
                Employee employee = new Employee(employeeModel.EmployeeName, employeeModel.DepartmentName
                    , employeeModel.IdNo, employeeModel.BirthDate);
                _employeeRepository.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            try
            {
                return _employeeRepository.GetEmployees()
                    .Select(c => new EmployeeViewModel
                    {
                        BirthDate = c.Birtdate,
                        DepartmentName = c.DepartmentName,
                        EmployeeId = c.Id,
                        EmployeeName = c.Name,
                        IdNo = c.IdNo,
                    }).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
    }
}
