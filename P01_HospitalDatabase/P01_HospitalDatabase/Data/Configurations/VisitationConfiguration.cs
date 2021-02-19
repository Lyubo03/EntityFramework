namespace P01_HospitalDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> visitation)
        {
            visitation
                .HasOne(v => v.Patient)
                .WithMany(v => v.Visitations);

            visitation
                .HasOne(d => d.Doctor)
                .WithMany(v => v.Visitations);
                
        }
    }
}