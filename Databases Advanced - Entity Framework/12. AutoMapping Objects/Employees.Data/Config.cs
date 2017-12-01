using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data
{
    public class Config
    {
        public static string ConnectionString => @"Server=(localdb)\MSSQLLocalDB;Database=Employees;Integrated Security=True;";
    }
}
