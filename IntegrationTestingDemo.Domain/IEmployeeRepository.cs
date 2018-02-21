using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Domain
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        bool AddEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);

        bool DeleteEmployee(Employee employee);

    }
}
