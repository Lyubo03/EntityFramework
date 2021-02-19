namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SalesDbContext();

            context.Database.Migrate();

            //var customer = new Customer
            //{
            //    Name = "Gosho Peshev",
            //    Email = "ilianTupalkata@gmail.com",
            //    CreditCardNumber = "neMiSeDavatPari"
            //};

            //var customer1 = new Customer
            //{
            //    Name = "Ivan Peshev",
            //    Email = "ilianTupalkata@gmail.com",
            //    CreditCardNumber = "neMiSeDavatPari"
            //};
            //var customer2 = new Customer
            //{
            //    Name = "edjflks Peshev",
            //    Email = "isdg.abdf",
            //    CreditCardNumber = "neMiSeDavatPari"
            //};
            //var customer3 = new Customer
            //{
            //    Name = "Smotlio Peshev",
            //    Email = "gsdg@gga.com",
            //    CreditCardNumber = "neMiSeDavatPari"
            //};

            //context.Customers.Add(customer);
            //context.Customers.Add(customer1);
            //context.Customers.Add(customer2);
            //context.Customers.Add(customer3);

            var store = new Store
            {
                Name = "Kaufland"
            };

            //context.Stores.Add(store);

            //var product = new Product
            //{
            //    Name = "Banana",
            //    Price = 2.5m,
            //    Quantity = 1.500,
            //};
            //var product1 = new Product
            //{
            //    Name = "Carrots",
            //    Price = 2.5m,
            //    Quantity = 3.500,
            //};
            //var product2 = new Product
            //{
            //    Name = "Oranges",
            //    Price = 4.5m,
            //    Quantity = 2.500,
            //};

            //context.Products.Add(product);
            //context.Products.Add(product2);
            //context.Products.Add(product1);

            context.Sales.Add(new Sale
            {
                Store = context.Stores.FirstOrDefault(),
                Product = context.Products.FirstOrDefault(),
                Customer = context.Customers.FirstOrDefault()
            });

            context.SaveChanges();
        }
    }
}