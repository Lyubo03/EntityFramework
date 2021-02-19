namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Models;

    public class SalesDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=Sales;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}