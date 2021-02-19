namespace ProductShop.App
{
    using System;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Collections.Generic;

    using Data;
    using System.Linq;
    public class StartUp
    {
        private static Random r = new Random();
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = config.CreateMapper();
            var context = new ProductShopContext();
            context.Database.Migrate();

            var users = new
            {
                usersCount = context.Users.Count(),

                users = context.Users
                .OrderByDescending(x => x.ProductsSold.Count())
                .ThenBy(x => x.LastName)
                .Where(x => x.ProductsSold.Count() > 0)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    count = x.ProductsSold.Count,
                    products = x.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price
                    }).ToArray()
                })
                .ToArray()
            };

            var jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(@"D:\Programing flex\EF\ProductShop\ProductShop.App\Json\users-and-products.json", jsonUsers);
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var result = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, result, true);
        }
    }
}