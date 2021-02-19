namespace BookShop.Configurations
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book
                .Property(b => b.Title)
                .HasMaxLength(50)
                .IsUnicode();

            book
            .Property(b => b.Title)
            .HasMaxLength(1000)
            .IsUnicode();
        }
    }
}