namespace Services
{
    using Banicharnica.Models;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly BanicharnicaContext context;

        public DbInitializerService(BanicharnicaContext context)
        {
            this.context = context;
        }
        public void IntializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}