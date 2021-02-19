namespace PetStore.Services.Interfaces
{
    public interface IBreedService
    {
        bool IsExists(int breedId);
        bool IsExists(string name);
        void Insert(string name);
    }
}