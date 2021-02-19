namespace CasSystem.Data.Configorations
{
    using CasSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car.HasOne(x => x.Model)
                   .WithMany(x => x.Cars)
                   .HasForeignKey(x => x.ModelId)
                   .OnDelete(DeleteBehavior.Restrict);

            car
            .HasIndex(c => c.Vin)
            .IsUnique();
        }
    }
}