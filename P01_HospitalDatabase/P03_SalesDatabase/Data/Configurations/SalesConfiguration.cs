namespace P03_SalesDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> sales)
        {
            sales.
                HasOne(s => s.Product)
                .WithMany(s => s.Sales);

            sales
                .HasOne(s => s.Store)
                .WithMany(s => s.Sales);

            sales
                .HasOne(s => s.Customer)
                .WithMany(s => s.Sales);
        }
    }
}