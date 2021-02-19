namespace PetStore.Services.Implementations
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore.Internal;
    using PetStore.Data;
    using PetStore.Models;
    using System;
    using System.Data;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext data;
        public CategoryService(PetStoreDbContext data)
        {
            this.data = data;
        }
        public void Insert(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            if (IsExists(name))
            {
                throw new ArgumentException("There is already such breed!");
            }

            var category = new Category()
            {
                Name = name,
                Description = description
            };

            data.Categories.Add(category);
            data.SaveChanges();
        }

        public bool IsExists(int categoryId) =>
            data.Categories.Any(c => c.Id == categoryId);
        public bool IsExists(string name) =>
           data.Categories.Any(c => c.Name.ToLower() == name.ToLower());

    }
}