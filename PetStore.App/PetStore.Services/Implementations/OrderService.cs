namespace PetStore.Services.Implementations
{
    using Interfaces;
    using PetStore.Data;

    public class OrderService : IOrderService
    {
        private PetStoreDbContext data;
        public OrderService(PetStoreDbContext data)
        {
            this.data = data;
        }

        public void CompleteOrder(int id)
        {
            var order = data.Orders
                 .Find(id);

            order.Status = PetStore.Models.OrderStatus.Done;
            this.data.SaveChanges();
        }
    }
}