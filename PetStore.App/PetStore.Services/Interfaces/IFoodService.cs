namespace PetStore.Services.Interfaces
{
    using Models.Food;
    using System;

    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, decimal profit,DateTime expirationDate, int brandId, int categoryId);
        void BuyFromDistributor(AddingFoodServiceModel model);
        void SellFoodToUser(int userId, int foodId);
    }
}