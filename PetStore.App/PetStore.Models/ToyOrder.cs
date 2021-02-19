namespace PetStore.Models
{
    public class ToyOrder
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Toy Toy { get; set; }
        public int ToyId { get; set; }
    }
}