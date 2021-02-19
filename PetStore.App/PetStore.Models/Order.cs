namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<FoodOrder> Foods { get; set; } = new HashSet<FoodOrder>();
        public ICollection<ToyOrder> ToyOrders { get; set; } = new HashSet<ToyOrder>();

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
    }
}