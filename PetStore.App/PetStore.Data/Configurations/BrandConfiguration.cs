namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> brand)
        {
            brand.HasMany(b => b.Foods)
                 .WithOne(b => b.Brand)
                 .HasForeignKey(b => b.BrandId)
                 .OnDelete(DeleteBehavior.Restrict);

            brand.HasMany(b => b.Toys)
            .WithOne(b => b.Brand)
            .HasForeignKey(b => b.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
