namespace PetStore.Services.Implementations
{
    using System;
    using PetStore.Data;
    using Interfaces;
    using PetStore.Models;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Linq;
    using System.Collections.Generic;
    using PetStore.Services.Models.Pets;

    public class PetService : IPetService
    {
        private const int PetsPageSize = 25;
        private readonly PetStoreDbContext data;
        private readonly IBreedService breedService;
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        public PetService(PetStoreDbContext data, IBreedService breedService, ICategoryService categoryService, IUserService userService)
        {
            this.data = data;
            this.breedService = breedService;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        public void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId)
        {
            if (!breedService.IsExists(breedId))
            {
                throw new ArgumentException("There is no such breed!");
            }

            if (!categoryService.IsExists(categoryId))
            {
                throw new ArgumentException("There is no such category");
            }

            if (price < 0)
            {
                throw new ArgumentException("Argument cannot be null");
            }

            var pet = new Pet()
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId
            };

            data.Add(pet);
            data.SaveChanges();
            Console.WriteLine("Successfully bought!");
        }

        public void SellPet(int petId, int userId)
        {
            if (!userService.Exists(userId))
            {
                throw new ArgumentException("There is no such user!");
            }

            if (!DoesExists(petId))
            {
                throw new ArgumentException("There is no such pet here!");
            }

            var pet = data.Pets.FirstOrDefault(p => p.Id == petId);

            var order = new Order()
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };
            pet.Order = order;
            data.Orders.Add(order);

            data.SaveChanges();
            Console.WriteLine("Successfully selled!");
        }
        public bool DoesExists(int petId) =>
            data.Pets.Any(p => p.Id == petId);

        public IEnumerable<PetListingServiceModel> All(int page = 1) =>
            this.data
            .Pets
            .Skip((page - 1) * PetsPageSize)
            .Take(PetsPageSize)
            .Select(p => new PetListingServiceModel
            {
                Id = p.Id,
                Price = p.Price,
                Category = p.Category.Name,
                Breed = p.Breed.Name
            });

        public int Total() => this.data.Pets.Count();

        public PetDetailServiceModels Details(int id)
        => data
            .Pets
            .Where(p => p.Id == id)
            .Select(p => new PetDetailServiceModels
            {
                Id = p.Id,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                Price = p.Price,
                Description = p.Description,
                Breed = p.Breed.Name,
                Category = p.Category.Name
            })
            .FirstOrDefault();

        public bool Delete(int id)
        {
            var pet = data.Pets.Find(id);

            if (pet == null)
            {
                return false;
            }

            data.Pets.Remove(pet);
            data.SaveChanges();

            return true;
        }
    }
}