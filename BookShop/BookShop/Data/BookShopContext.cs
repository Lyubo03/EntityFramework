namespace BookShop.Data
{
    using BookShop.Migrations;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Enums;
    public class BookShopContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer(@"Server=DESKTOP-2RO7KG1\SQLEXPRESS;Database=BookShop;Integrated Security=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(typeof(BookShopContext).Assembly);
    }
}