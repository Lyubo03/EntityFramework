namespace PetStore.Services.Models.Pets
{
    public class PetListingServiceModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Breed { get; set; }
        public decimal Price { get; set; }
    }
}