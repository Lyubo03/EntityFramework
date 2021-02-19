namespace PetStore.Services.Interfaces
{
    using Models.Toy;

    public interface IToyService
    {
        void BuyFromDistributer(string name, string description, decimal distributorPrice, decimal profit, int brandId, int categoryId);
        void BuyFromDistributer(ToyServiceModel model);
        void SellToyToUser(int userId, int toyId);
    }
}