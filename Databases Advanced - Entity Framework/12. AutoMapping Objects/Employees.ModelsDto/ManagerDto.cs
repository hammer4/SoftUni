using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.ModelsDto
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeDto> EmployeeDtos { get; set; }
        public int EmployeesCount { get; set; }
    }
}
