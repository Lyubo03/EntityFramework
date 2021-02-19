namespace BookShop.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //50char, unicode
        public ICollection<BookCategory> CategoryBooks { get; set; } = new HashSet<BookCategory>();
    }
}