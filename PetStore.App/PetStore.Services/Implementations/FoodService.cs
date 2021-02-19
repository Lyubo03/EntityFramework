namespace PetStore.Services.Implementations
{
    using Interfaces;
    using Models.Food;
    using Data;
    using PetStore.Models.Foods;
    using System;
    using PetStore.Models;
    using System.Linq;

    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;
        private readonly IUserService userService;
        public FoodService(PetStoreDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }
        public void BuyFromDistributor(string name, double weight, decimal price, decimal profit,DateTime expirationDate, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cannot be null or whitespace!");
            }

            if (profit < 0 || profit > 2)
            {
                throw new ArgumentException("Profit must be higher than zero and Lower than 200%");
            }
            var food = new Food()
            {
                Name = name,
                Weight = weight,
                DestributorPrice = price,
                Price = price + (price * profit),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Foods.Add(food);
            data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (model.Profit < 0 || model.Profit > 2)
            {
                throw new ArgumentException("Profit must be higher than zero and Lower than 200%");
            }

            var food = new Food()
            {
                Name = model.Name,
                Weight = model.Weight,
                DestributorPrice = model.DistributorPrice,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            data.Foods.Add(food);
            data.SaveChanges();
        }
        public bool IsFoodExist(int foodId)
        {
            return data
                .Foods
                .Any(f => f.Id == foodId);
        }

        public void SellFoodToUser(int userId, int foodId)
        {
            if (!userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user!");
            }

            if (!IsFoodExist(foodId))
            {
                throw new ArgumentException("There is no such food!");
            }

            var order = new Order()
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };
            data.Orders.Add(order);

            var foodOrder = new FoodOrder()
            {
                FoodId = foodId,
                Order = order
            };
            data.FoodOrders.Add(foodOrder);

            data.SaveChanges();
        }
    }
}