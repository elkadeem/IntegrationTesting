using IntegrationTestingDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Infra
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesDbContext _employeesDbContext;
        public EmployeeRepository(EmployeesDbContext employeesDbContext)
        {
            if (employeesDbContext == null)
                throw new ArgumentNullException(nameof(employeesDbContext));

            _employeesDbContext = employeesDbContext;
        }

        public bool AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _employeesDbContext.Employees.Add(employee);
            _employeesDbContext.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            
            _employeesDbContext.Employees.Remove(employee);
            _employeesDbContext.SaveChanges();
            return true;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeesDbContext.Employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeesDbContext.Employees.ToList();
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var entry = _employeesDbContext.Entry<Employee>(employee);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                _employeesDbContext.Employees.Attach(employee);
                entry = _employeesDbContext.Entry<Employee>(employee);
            }
            entry.State = System.Data.Entity.EntityState.Modified;
            _employeesDbContext.SaveChanges();
            return true;
        }
    }
}
