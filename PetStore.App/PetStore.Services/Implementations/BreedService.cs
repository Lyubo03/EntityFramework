namespace PetStore.Services.Implementations
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore.Internal;
    using PetStore.Data;
    using PetStore.Models;
    using System;
    using System.Linq;

    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext data;

        public BreedService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void Insert(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (IsExists(name))
            {
                throw new InvalidOperationException("There is already such breed!");
            }

            var breed = new Breed()
            {
                Name = name
            };

            data.Breeds.Add(breed);
            data.SaveChanges();
        }
        public bool IsExists(int breedId) =>
            data.Breeds.Any(b => b.Id == breedId);
        public bool IsExists(string name) =>
            data.Breeds.Any(b => b.Name.ToLower() == name.ToLower());
    }
}