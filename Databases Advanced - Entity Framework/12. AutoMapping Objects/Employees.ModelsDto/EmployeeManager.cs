using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.ModelsDto
{
    public class EmployeeManager
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerLastName { get; set; }
    }
}
