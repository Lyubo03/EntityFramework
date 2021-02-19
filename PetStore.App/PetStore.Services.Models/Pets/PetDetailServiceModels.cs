namespace PetStore.Services.Models.Pets
{
    using PetStore.Models;
    using System;

    public class PetDetailServiceModels
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BreedId { get; set; }
        public string Breed { get; set; }
        public string Category { get; set; }
    }
}
