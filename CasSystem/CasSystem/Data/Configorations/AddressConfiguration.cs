namespace CasSystem.Data.Configorations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {        
            address
                    .HasOne(c => c.Customer)
                    .WithOne(a => a.Address)
                    .HasForeignKey<Address>(a => a.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}