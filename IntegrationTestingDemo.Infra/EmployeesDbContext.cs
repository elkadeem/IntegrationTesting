using IntegrationTestingDemo.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Infra
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext() : this("name=EmployeeConnectionString")
        {

        }

        public EmployeesDbContext(string nameOrConnectionString): base(nameOrConnectionString)
        {
            Database.SetInitializer<EmployeesDbContext>(null);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
