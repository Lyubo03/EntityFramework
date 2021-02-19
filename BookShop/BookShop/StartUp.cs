namespace BookShop
{
    using BookShop.Data.Enums;
    using BookShop.Data.Models;
    using Data;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(t => t.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(t => t.BookId)
                .ToList()
                .ForEach(b => sb.AppendLine(b.Title));


            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(t => t.Copies < 5000)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(t => t.Price)
                .ToList()
                .ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price}"));


            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(t => t.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(t => t.BookId)
                .ToList()
                .ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var titles = context.Books
                .Where(b => b.BookCategories
                            .Any(bc => categories
                                        .Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, titles);

        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                    b.EditionType,
                    b.ReleaseDate
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .Select(a => a.FirstName + ' ' + a.LastName)
                .ToList();


            return string.Join(Environment.NewLine, authors);
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
               //Escape Casing 
               .Where(b => b.Title.ToUpper().Contains(input.ToUpper()))
               .OrderBy(b => b.Title)
               .Select(b => b.Title)
               .ToList()
               .ForEach(b => sb.AppendLine($"{b}"));


            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
               //Escape Casing 
               .Where(b => b.Author.LastName.ToUpper().StartsWith(input.ToUpper()))
               .Select(b => new
               {
                   b.Title,
                   b.Author.FirstName,
                   b.Author.LastName
               })
               .ToList()
               .ForEach(b => sb.AppendLine($"{b.Title} ({b.FirstName} {b.LastName})"));


            return sb.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Authors
                .Select(b => new
                {
                    b.FirstName,
                    b.LastName,
                    Copies = b.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToList()
                .ForEach(c => sb.AppendLine($"{c.FirstName} {c.LastName} - {c.Copies}"));

            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Categories
               .Select(s => new
               {
                   s.Name,
                   Profit = s.CategoryBooks.Sum(c => c.Book.Price * c.Book.Copies)
               })
               .OrderByDescending(p => p.Profit)
               .ThenBy(p => p.Name)
               .ToList()
               .ForEach(c => sb.AppendLine($"{c.Name} ${c.Profit}"));

            return sb.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoriesBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(b => new
                    {
                        b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate.Value.Year
                    })
                    .Take(3)
                    .OrderByDescending(b => b.ReleaseDate)
                    .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categoriesBooks)
            {
                sb.AppendLine("--" + category.Name);

                foreach (var books in category.Books)
                {
                    sb.AppendLine($"{books.Title} ({books.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                 .Where(b => b.ReleaseDate.Value.Year < 2010)
                 .Update(x => new Book { Price = x.Price + 5 });

            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var affectedRows = context.Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return affectedRows;
        }
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                // var input = int.Parse(Console.ReadLine());
                Console.WriteLine(RemoveBooks(context)); 
            }

        }
    }
}