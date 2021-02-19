namespace PetStore.Services.Implementations
{
    using Interfaces;
    using PetStore.Data;
    using PetStore.Models;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private PetStoreDbContext data;

        public UserService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public bool Exists(int userId)
        {
            return data
                .Users
                .Any(u => u.Id == userId);
        }

        public void RegisterUser(string name, string email)
        {
            if (data.Users.Any(u => u.Name == name && u.Email == email ))
            {
                throw new InvalidOperationException("There is already such an user!");
            }

            var user = new User()
            {
                Name = name,
                Email = email
            };

            data.Users.Add(user);
            data.SaveChanges();
            Console.WriteLine("User added successfully!");
        }
    }
}