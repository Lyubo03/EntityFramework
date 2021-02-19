namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using System.Reflection;

    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> Prescriptions{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=Hospital;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}