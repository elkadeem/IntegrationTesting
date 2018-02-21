using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Domain
{
    public class Employee
    {
        private Employee()
        {
        }

        public Employee(string name, string departmentName, string idNo, DateTime birtdate)
        {

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(departmentName))
                throw new ArgumentNullException(nameof(departmentName));
            if (string.IsNullOrEmpty(idNo))
                throw new ArgumentNullException(nameof(idNo));
            if (birtdate.Date > DateTime.Today.AddYears(-18))
                throw new ArgumentOutOfRangeException(nameof(birtdate), "Employee Should be 18 years old.");

            Id = Guid.NewGuid();
            Name = name;
            DepartmentName = departmentName;
            IdNo = idNo;
            Birtdate = birtdate;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string DepartmentName { get; private set; }
        public string IdNo { get; private set; }
        public DateTime Birtdate { get; private set; }

        public void UpdateEmployee(string name, string departmentName, DateTime birtdate)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(departmentName))
                throw new ArgumentNullException(nameof(departmentName));
            if (birtdate.Date > DateTime.Today.AddYears(18))
                throw new ArgumentOutOfRangeException(nameof(birtdate), "Employee Should be 18 years old.");

            Name = name;
            DepartmentName = departmentName;            
            Birtdate = birtdate;
        }
    }
}
