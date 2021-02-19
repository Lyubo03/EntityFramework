namespace PetStore.Services.Implementations
{
    using PetStore.Services.Models.Brand;
    using System.Collections.Generic;
    using Data;
    using PetStore.Models;
    using System;
    using System.Linq;

    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;
        public BrandService(PetStoreDbContext context) => data = context;
        public int Create(string name)
        {
            if (data.Brands.Any(x => x.Name.ToLower() == name.ToLower()))
            {
                throw new ArgumentException($"Brand {name} already exists!");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLength}");
            }

            var brand = new Brand
            {
                Name = name
            };
            this.data.Brands.Add(brand);
            return brand.Id;
        }

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
            => this.data.Brands
                .Where(b => b.Name.ToUpper().Contains(name.ToUpper()))
                .Select(b => new BrandListingServiceModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
        internal Brand GetBrandByName(string name) => data.Brands
            .FirstOrDefault(b => b.Name.ToLower() == name.ToLower());
    }
}