namespace PetStore.App
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Data;
    using PetStore.Models;
    using PetStore.Services.Implementations;
    using PetStore.Services.Interfaces;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static Random r = new Random();
        public static void Main(string[] args)
        {
            using (PetStoreDbContext data = new PetStoreDbContext())
            {
                for (int i = 0; i < 100; i++)
                {
                    int n = r.Next(1, 101);

                    var category = data
                                .Categories
                                .OrderBy(c => Guid.NewGuid())
                                .Select(c => c.Id)
                                .FirstOrDefault();

                    var breed = data
                        .Breeds
                        .OrderBy(c => Guid.NewGuid())
                                .Select(c => c.Id)
                                .FirstOrDefault();

                    var pet = new Pet
                    {
                        DateOfBirth = DateTime.UtcNow.AddDays(-20 - i * 2),
                        Price = 50 + i * 10,
                        Gender = i >= n ? Gender.Male : Gender.Female,
                        Description = "Random Description" + i,
                        BreedId = breed,
                        CategoryId = category
                    };
                    data.Pets.Add(pet);

                }
                data.SaveChanges();
            }
        }
    }
}