using PhotoShare.Data;
using PhotoShare.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace PhotoShare.Services
{
    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly PhotoShareContext context;

        public DatabaseInitializerService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.EnsureCreated();
        }
    }
}
