namespace CasSystem.Data.Configorations
{
    using CasSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
            .HasIndex(m => m.Name)
            .IsUnique();

            make.HasMany(m => m.Models)
        .WithOne(m => m.Make)
        .HasForeignKey(m => m.MakeID)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}