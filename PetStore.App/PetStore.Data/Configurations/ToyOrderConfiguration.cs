namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> order)
        {
            order
                .HasKey(o => new { o.ToyId, o.OrderId });

            order
                .HasOne(o => o.Toy)
                .WithMany(t => t.ToyOrders)
                .HasForeignKey(o => o.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            order
                .HasOne(o => o.Order)
                .WithMany(o => o.ToyOrders)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}