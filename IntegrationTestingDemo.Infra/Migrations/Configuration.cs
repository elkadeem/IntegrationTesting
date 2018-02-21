namespace IntegrationTestingDemo.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<IntegrationTestingDemo.Infra.EmployeesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IntegrationTestingDemo.Infra.EmployeesDbContext context)
        {
            context.Employees.AddOrUpdate(c => c.IdNo, new Domain.Employee("Ahmed", "Dev", "111", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo, new Domain.Employee("Mohamed", "Dev", "112", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo, new Domain.Employee("Ali", "Dev", "123", DateTime.Today.AddYears(-30)));
            context.Employees.AddOrUpdate(c => c.IdNo
            , new Domain.Employee("Mahmoud", "Dev", "124", DateTime.Today.AddYears(-30)));

            context.SaveChanges();
        }
    }
}
