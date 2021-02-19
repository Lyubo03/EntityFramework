namespace PetStore.Services.Implementations
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore.Internal;
    using Models.Toy;
    using PetStore.Data;
    using PetStore.Models;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security.Cryptography.X509Certificates;

    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;
        public ToyService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void BuyFromDistributer(string name, string description, decimal distributorPrice, decimal profit, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name cannot be null or whitespace!");
            }

            if (profit < 0 || profit > 2)
            {
                throw new ArgumentException("The profit cannot be greater than null or less than 2!");
            }

            var toy = new Toy()
            {
                Name = name,
                Description = description,
                DistributorPrice = distributorPrice,
                Price = distributorPrice + (distributorPrice * profit),
                BrandId = brandId,
                CategoryId = categoryId
            };

            data.Toys.Add(toy);
            data.SaveChanges();
        }

        public void BuyFromDistributer(ToyServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("The name cannot be null or whitespace!");
            }

            if (model.Profit > 0 || model.Profit < 2)
            {
                throw new ArgumentException("The profit cannot be greater than null or less than 2!");
            }

            var toy = new Toy()
            {
                Name = model.Name,
                Description = model.Description,
                DistributorPrice = model.DistributorPrice,
                Price = model.DistributorPrice + (model.DistributorPrice * model.Profit),
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            data.Toys.Add(toy);
            data.SaveChanges();
        }
        public bool IsToyExists(int toyId)
        {
            return data
                .Toys
                .Any(t => t.Id == toyId); 
        }

        public void SellToyToUser(int userId, int toyId)
        {
            if (!userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user!");
            }

            if(!IsToyExists(toyId))
            {
                throw new ArgumentException("There is no such toy!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };
            data.Orders.Add(order);

            var toyOrder = new ToyOrder()
            {
                Order = order,
                ToyId = toyId
            };

            data.ToyOrders.Add(toyOrder);
            data.SaveChanges();
        }
    }
}