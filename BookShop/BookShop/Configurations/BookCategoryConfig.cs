namespace BookShop.Configurations
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder
                .HasKey(b => new { b.BookId, b.CategoryId});

            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.BookId);

            builder
                .HasOne(b => b.Category)
                .WithMany(b => b.CategoryBooks)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}