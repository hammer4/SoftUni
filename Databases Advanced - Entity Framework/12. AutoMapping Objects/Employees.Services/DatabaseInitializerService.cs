using Employees.Data;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class DatabaseInitializerService
    {
        private readonly EmployeesContext context;

        public DatabaseInitializerService(EmployeesContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.Migrate();
        }
    }
}
