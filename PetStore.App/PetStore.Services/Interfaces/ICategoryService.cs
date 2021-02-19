namespace PetStore.Services.Interfaces
{
    public interface ICategoryService
    {
        void Insert(string name, string description);
        bool IsExists(int categoryId);
    }
}