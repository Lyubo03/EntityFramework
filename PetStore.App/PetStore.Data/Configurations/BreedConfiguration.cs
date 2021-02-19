namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
    public class BreedConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> pet)
        {
            pet
                .HasOne(b => b.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(b => b.BreedId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}