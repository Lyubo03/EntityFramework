namespace PetStore.Services.Interfaces
{
    using PetStore.Models;
    using PetStore.Services.Models.Pets;
    using System;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> All(int page = 1);
        PetDetailServiceModels Details(int id);
        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);
        void SellPet(int petId, int userId);
        bool DoesExists(int petId);
        int Total();
        bool Delete(int id);
    }
}