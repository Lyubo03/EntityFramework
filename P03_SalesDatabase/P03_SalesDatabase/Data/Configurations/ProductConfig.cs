namespace P03_SalesDatabase.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");
        }
    }
}