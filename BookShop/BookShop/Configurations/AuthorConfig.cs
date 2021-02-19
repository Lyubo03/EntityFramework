namespace BookShop.Configurations
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired(false);
            
            author
                .Property(a => a.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            author
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}