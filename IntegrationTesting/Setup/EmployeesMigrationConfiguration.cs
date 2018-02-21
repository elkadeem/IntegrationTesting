namespace IntegrationTesting
{
    using IntegrationTestingDemo.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class EmployeesMigrationConfiguration : DbMigrationsConfiguration<IntegrationTestingDemo.Infra.EmployeesDbContext>
    {
        public EmployeesMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IntegrationTestingDemo.Infra.EmployeesDbContext context)
        {
            context.Employees.AddOrUpdate(c => c.IdNo, new Employee("Ahmed", "Dev", "111", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo, new Employee("Mohamed", "Dev", "112", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo, new Employee("Ali", "Dev", "123", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo
            , new Employee("Mahmoud", "Dev", "124", DateTime.Today.AddYears(-30)));

            context.SaveChanges();
        }
    }
}
