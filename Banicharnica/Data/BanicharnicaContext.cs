namespace Banicharnica.Models
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class BanicharnicaContext : DbContext
    {
        public BanicharnicaContext()
        {
            
        }

        public BanicharnicaContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Employee>()
                .Property(e => e.FirstName)
                .IsRequired()

                .HasMaxLength(15)
                .IsUnicode();

            builder
                .Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode();

            builder
                .Entity<Employee>()
                .Property(e => e.Salary)
                .IsRequired();

            builder.Entity<Employee>(entity =>
            {
                entity.HasOne(x => x.Manager)
                .WithMany(x => x.ManagerEmployee)
                .HasForeignKey(x => x.ManagerId);
            });
        }
    }
}