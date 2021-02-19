namespace CasSystem
{
    using CasSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new CarDBContext();
            context.Database.Migrate();

            var customer = new Customer
            {
                FirstName = "Pesho",
                LastName = "Goshev",
                Age = 8012749
            };

            var validationContext = new ValidationContext(customer);

            Validator.ValidateObject(customer, validationContext,true);

            context.Customers.Add(customer);

            context.SaveChanges();
        }
    }
}