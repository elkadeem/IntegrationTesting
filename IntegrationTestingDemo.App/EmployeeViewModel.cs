using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.App
{
    public class EmployeeViewModel
    {
        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string IdNo { get; set; }

        public string DepartmentName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
