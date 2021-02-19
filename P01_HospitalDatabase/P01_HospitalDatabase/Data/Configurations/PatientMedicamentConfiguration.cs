namespace P01_HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class PatientMedicamentConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> perscription)
        {
            perscription
                .HasKey(p => new { p.PatientId, p.MedicamentId });

            perscription
                .HasOne(p => p.Patient)
                .WithMany(m => m.Perscription)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            perscription
                .HasOne(m => m.Medicament)
                .WithMany(p => p.Perscription)
                .HasForeignKey(m => m.MedicamentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}