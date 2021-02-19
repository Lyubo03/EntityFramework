namespace P01_HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> diagnose)
        {
            diagnose
                .HasOne(d => d.Patient)
                .WithMany(d => d.Diagnoses)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}