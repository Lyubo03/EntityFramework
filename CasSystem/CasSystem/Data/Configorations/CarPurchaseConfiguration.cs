namespace CasSystem.Data.Configorations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CarPurchaseConfiguration : IEntityTypeConfiguration<CarPurchase>
    {
        public void Configure(EntityTypeBuilder<CarPurchase> purchase)
        {
            purchase
            .HasKey(p => new { p.CustomerId, p.CarId });

            purchase
            .HasOne(c => c.Customer)
            .WithMany(c => c.Purchases)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            purchase
            .HasOne(c => c.Car)
            .WithMany(c => c.Purchases)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}